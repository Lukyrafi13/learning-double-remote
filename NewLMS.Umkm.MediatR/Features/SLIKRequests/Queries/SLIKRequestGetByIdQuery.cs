using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequests.Queries
{
    public class SLIKRequestGetByIdQuery : IRequest<ServiceResponse<SLIKRequestResponse>>
    {
        public Guid Id { get; set; }
    }

    public class SLIKRequestGetByIdQueryHandler : IRequestHandler<SLIKRequestGetByIdQuery, ServiceResponse<SLIKRequestResponse>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public SLIKRequestGetByIdQueryHandler(IGenericRepositoryAsync<SLIKRequest> slikRequest, IMapper mapper, IConfiguration config)
        {
            _slikRequest = slikRequest;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ServiceResponse<SLIKRequestResponse>> Handle(SLIKRequestGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]
                {
                    "LoanApplication.RfBookingBranch",
                    "LoanApplication.RfProduct",
                    "LoanApplication.Debtor",
                    "LoanApplication.DebtorCompany",
                    "LoanApplication.RfOwnerCategory",
                    "LoanApplication.Owner",
                    "SLIKRequestDebtors"
                };

                var data = await _slikRequest.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SLIKRequestResponse>.Return404("Data SLIKRequest tidak ditemukan.");

                var dataVm = _mapper.Map<SLIKRequestResponse>(data);

                return ServiceResponse<SLIKRequestResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<SLIKRequestResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
