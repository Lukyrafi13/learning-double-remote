using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppAgunans.Commands
{
    public class AppAgunanPostCommand : AppAgunanPostRequestDto, IRequest<ServiceResponse<AppAgunanResponseDto>>
    {

    }
    public class AppAgunanPostCommandHandler : IRequestHandler<AppAgunanPostCommand, ServiceResponse<AppAgunanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private readonly IMapper _mapper;

        public AppAgunanPostCommandHandler(IGenericRepositoryAsync<AppAgunan> AppAgunan, IMapper mapper)
        {
            _AppAgunan = AppAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppAgunanResponseDto>> Handle(AppAgunanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var AppAgunan = _mapper.Map<AppAgunan>(request);

                var returnedAppAgunan = await _AppAgunan.AddAsync(AppAgunan, callSave: false);

                // var response = _mapper.Map<AppAgunanResponseDto>(returnedAppAgunan);
                var response = _mapper.Map<AppAgunanResponseDto>(returnedAppAgunan);

                await _AppAgunan.SaveChangeAsync();
                return ServiceResponse<AppAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}