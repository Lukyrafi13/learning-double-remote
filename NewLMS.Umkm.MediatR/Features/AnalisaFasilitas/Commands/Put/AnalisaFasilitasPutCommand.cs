using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Commands
{
    public class AnalisaFasilitasPutCommand : AnalisaFasilitasPutRequestDto, IRequest<ServiceResponse<AnalisaFasilitasResponseDto>>
    {
    }

    public class PutAnalisaFasilitasCommandHandler : IRequestHandler<AnalisaFasilitasPutCommand, ServiceResponse<AnalisaFasilitasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public PutAnalisaFasilitasCommandHandler(IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas, IMapper mapper)
        {
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaFasilitasResponseDto>> Handle(AnalisaFasilitasPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAnalisaFasilitas = await _AnalisaFasilitas.GetByIdAsync(request.Id, "Id");
                
                existingAnalisaFasilitas = _mapper.Map<AnalisaFasilitasPutRequestDto, AnalisaFasilitas>(request, existingAnalisaFasilitas);

                await _AnalisaFasilitas.UpdateAsync(existingAnalisaFasilitas);

                var response = _mapper.Map<AnalisaFasilitasResponseDto>(existingAnalisaFasilitas);

                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}