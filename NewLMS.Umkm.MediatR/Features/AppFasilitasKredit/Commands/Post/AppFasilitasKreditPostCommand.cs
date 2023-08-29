using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppFasilitasKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppFasilitasKredits.Commands
{
    public class AppFasilitasKreditPostCommand : AppFasilitasKreditPostRequestDto, IRequest<ServiceResponse<AppFasilitasKreditResponseDto>>
    {

    }
    public class AppFasilitasKreditPostCommandHandler : IRequestHandler<AppFasilitasKreditPostCommand, ServiceResponse<AppFasilitasKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
        private readonly IMapper _mapper;

        public AppFasilitasKreditPostCommandHandler(IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit, IMapper mapper)
        {
            _AppFasilitasKredit = AppFasilitasKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppFasilitasKreditResponseDto>> Handle(AppFasilitasKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var AppFasilitasKredit = _mapper.Map<AppFasilitasKredit>(request);

                var returnedAppFasilitasKredit = await _AppFasilitasKredit.AddAsync(AppFasilitasKredit, callSave: false);

                // var response = _mapper.Map<AppFasilitasKreditResponseDto>(returnedAppFasilitasKredit);
                var response = _mapper.Map<AppFasilitasKreditResponseDto>(returnedAppFasilitasKredit);

                await _AppFasilitasKredit.SaveChangeAsync();
                return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}