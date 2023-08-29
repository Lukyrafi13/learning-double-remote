using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaSandiOJKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSandiOJKs.Commands
{
    public class AnalisaSandiOJKPutCommand : AnalisaSandiOJKPutRequestDto, IRequest<ServiceResponse<AnalisaSandiOJKResponseDto>>
    {
    }

    public class PutAnalisaSandiOJKCommandHandler : IRequestHandler<AnalisaSandiOJKPutCommand, ServiceResponse<AnalisaSandiOJKResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
        private readonly IMapper _mapper;

        public PutAnalisaSandiOJKCommandHandler(IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK, IMapper mapper)
        {
            _AnalisaSandiOJK = AnalisaSandiOJK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaSandiOJKResponseDto>> Handle(AnalisaSandiOJKPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAnalisaSandiOJK = await _AnalisaSandiOJK.GetByIdAsync(request.Id, "Id");

                existingAnalisaSandiOJK = _mapper.Map<AnalisaSandiOJKPutRequestDto, AnalisaSandiOJK>(request, existingAnalisaSandiOJK);

                await _AnalisaSandiOJK.UpdateAsync(existingAnalisaSandiOJK);

                var response = _mapper.Map<AnalisaSandiOJKResponseDto>(existingAnalisaSandiOJK);

                return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}