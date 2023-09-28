using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands
{
    public class SLIKRequestDebtorProcessCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid Id { get; set; }
    }

    public class SLIKRequestDebtorProcessCommandHandler : IRequestHandler<SLIKRequestDebtorProcessCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IMapper _mapper;

        public SLIKRequestDebtorProcessCommandHandler(IGenericRepositoryAsync<SLIKRequest> slikRequest, IMapper mapper)
        {
            _slikRequest = slikRequest;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestDebtorProcessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequest = await _slikRequest.GetByIdAsync(request.Id, "Id") ?? throw new NullReferenceException("Data SLIK tidak ditemukan.");
                slikRequest.StageId = UMKMConst.Stages["SLIKRequestAKBL"];

                await _slikRequest.UpdateAsync(slikRequest);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
