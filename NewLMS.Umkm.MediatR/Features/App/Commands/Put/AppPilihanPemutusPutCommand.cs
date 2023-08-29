using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Apps.Commands
{
    public class AppPilihanPemutusPutCommand : AppPilihanPemutusPutRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }
    public class AppPilihanPemutusPutCommandHandler : IRequestHandler<AppPilihanPemutusPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<App> _app;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public AppPilihanPemutusPutCommandHandler(
            IGenericRepositoryAsync<App> app,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _app = app;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppPilihanPemutusPutCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var existingApp = await _app.GetByIdAsync(request.Id, "Id");

                existingApp.RFPilihanPemutusId = request.RFPilihanPemutusId;

                await _app.UpdateAsync(existingApp);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}