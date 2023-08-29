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
    public class AnalisaFasilitasPostCommand : AnalisaFasilitasPostRequestDto, IRequest<ServiceResponse<AnalisaFasilitasResponseDto>>
    {

    }
    public class AnalisaFasilitasPostCommandHandler : IRequestHandler<AnalisaFasilitasPostCommand, ServiceResponse<AnalisaFasilitasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public AnalisaFasilitasPostCommandHandler(IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas, IMapper mapper)
        {
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaFasilitasResponseDto>> Handle(AnalisaFasilitasPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var AnalisaFasilitas = _mapper.Map<AnalisaFasilitas>(request);

                var returnedAnalisaFasilitas = await _AnalisaFasilitas.AddAsync(AnalisaFasilitas, callSave: false);

                // var response = _mapper.Map<AnalisaFasilitasResponseDto>(returnedAnalisaFasilitas);
                var response = _mapper.Map<AnalisaFasilitasResponseDto>(returnedAnalisaFasilitas);

                await _AnalisaFasilitas.SaveChangeAsync();
                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}