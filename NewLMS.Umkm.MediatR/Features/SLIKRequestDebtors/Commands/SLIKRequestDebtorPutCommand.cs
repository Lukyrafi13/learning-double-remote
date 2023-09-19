using AutoMapper;
using MediatR;
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
    public class SLIKRequestDebtorPutCommand : SLIKRequestDebtorRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class SLIKRequestDebtorPutCommandHandler : IRequestHandler<SLIKRequestDebtorPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly IMapper _mapper;

        public SLIKRequestDebtorPutCommandHandler(IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, IMapper mapper)
        {
            _slikRequestDebtor = slikRequestDebtor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestDebtorPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequestDebtor = await _slikRequestDebtor.GetByIdAsync(request.Id) ?? throw new NullReferenceException("Data Debitur tidak ditemukan.") ?? throw new NullReferenceException("Data SLIK Debtor tidak ditemukan.");
                var slikId = slikRequestDebtor.SLIKRequestId;
                var slikRequestDebtorId = slikRequestDebtor.Id;

                slikRequestDebtor = _mapper.Map<SLIKRequestDebtor>(request);
                slikRequestDebtor.Id = slikRequestDebtorId;
                slikRequestDebtor.SLIKRequestId = slikId;

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
