using MediatR;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands
{
    public class SLIKRequestDebtorDeleteCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid Id { get; set; }
    }

    public class SLIKRequestDebtorDeleteCommandHandler : IRequestHandler<SLIKRequestDebtorDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly ICurrentUserService _currentUserService;

        public SLIKRequestDebtorDeleteCommandHandler(IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, ICurrentUserService currentUserService)
        {
            _slikRequestDebtor = slikRequestDebtor;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestDebtorDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequestDebtor = await _slikRequestDebtor.GetByIdAsync(request.Id, "Id");

                slikRequestDebtor.IsDeleted = true;
                slikRequestDebtor.DeletedBy = Guid.Parse(_currentUserService.Id);

                await _slikRequestDebtor.UpdateAsync(slikRequestDebtor);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
