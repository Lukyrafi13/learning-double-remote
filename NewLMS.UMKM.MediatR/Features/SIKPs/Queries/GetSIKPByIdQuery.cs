using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.SIKPs;

namespace NewLMS.UMKM.MediatR.Features.SIKPs.Queries
{
    public class SIKPRequestRequest
    {
        public Guid Id { get; set; }
    }

    public class GetSIKPByIdQuery : SIKPRequestRequest, IRequest<ServiceResponse<SIKPBaseResponse>>
    {
    }

    public class GetSIKPByIdQueryHandler : IRequestHandler<GetSIKPByIdQuery, ServiceResponse<SIKPBaseResponse>>
    {
        private IGenericRepositoryAsync<NewLMS.UMKM.Data.Entities.SIKP> _sikp;
        private readonly IMapper _mapper;

        public GetSIKPByIdQueryHandler(IMapper mapper, IGenericRepositoryAsync<Data.Entities.SIKP> sikp)
        {
            _mapper = mapper;
            _sikp = sikp;
        }
        public async Task<ServiceResponse<SIKPBaseResponse>> Handle(GetSIKPByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sikpIncludes = new string[] {
					    "LoanApplication.RfOwnerCategory",
                        "LoanApplication.Debtor.RfJob",
                        "SIKPRequest.RfSectorLBU3.RfSectorLBU2.RfSectorLBU1",
						"SIKPRequest.RfGender",
						"SIKPRequest.RfMarital",
						"SIKPRequest.RfEducation",
						"SIKPRequest.DebtorRfZipCode",
						"SIKPRequest.DebtorCompanyRfZipCode",
						"SIKPRequest.DebtorCompanyRfLinkage",
						"SIKPResponse.RfGender",
						"SIKPResponse.RfMarital",
						"SIKPResponse.RfEducation",
						"SIKPResponse.DebtorRfZipCode",
						"SIKPResponse.DebtorCompanyRfZipCode",
						"SIKPResponse.DebtorCompanyRfLinkage",
                    };
                var data = await _sikp.GetByIdAsync(request.Id, "Id", sikpIncludes);
                if (data == null)
                    return ServiceResponse<SIKPBaseResponse>.ReturnResultWith204();
                var dataVm = _mapper.Map<SIKPBaseResponse>(data);

                return ServiceResponse<SIKPBaseResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPBaseResponse>.ReturnException(ex);
            }
        }
    }
}