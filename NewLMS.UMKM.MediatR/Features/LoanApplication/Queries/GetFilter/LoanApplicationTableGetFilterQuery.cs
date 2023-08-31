using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Queries
{
    public class LoanApplicationTableGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationTableResponse>>>
    {
    }

    public class LoanApplicationTableGetFilterQueryHandler : IRequestHandler<LoanApplicationTableGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private IGenericRepositoryAsync<LoanApplicationStageLogs> _LoanApplicationStageLogs;
        private readonly IMapper _mapper;

        public LoanApplicationTableGetFilterQueryHandler(
                IGenericRepositoryAsync<LoanApplication> LoanApplication,
                IGenericRepositoryAsync<LoanApplicationStageLogs> LoanApplicationStageLogs,
                IMapper mapper
            )
        {
            _LoanApplication = LoanApplication;
            _LoanApplicationStageLogs = LoanApplicationStageLogs;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationTableResponse>>> Handle(LoanApplicationTableGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "Debtor",
                "BookingOffice",
                "Prospect",
                "Prospect.RfBranch",
                "Prospect.RfProduct",
                "Prospect.RfOwnerCategory",
                "LoanApplicationStageLogs",
                "LoanApplicationStageLogs.RfStage",
            };
            var data = await _LoanApplication.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<LoanApplicationTableResponse>>(data.Results);
            IEnumerable<LoanApplicationTableResponse> dataVm;
            var listResponse = new List<LoanApplicationTableResponse>();

            foreach (var result in data.Results){
                var response = new LoanApplicationTableResponse();

                response.Id = result.Id;
                response.AplikasiId = result.LoanApplicationId;
                response.CustomerName = result.Debtor.Fullname;
                response.BookingOffice = result.Prospect.RfBranch.Code +" - "+result.Prospect.RfBranch.Name;
                response.NamaAO = result.Prospect.AccountOfficer;
                response.ProductLengkap = result.Prospect.RfProduct.ProductDesc +" - "+result.Prospect.RfOwnerCategory.OwnDesc;
                response.Product = result.Prospect.RfProduct.ProductDesc;
                response.SumberData = result.Prospect.DataSource;
                response.Stage = result.LatestStage;
                response.Age = (DateTime.Now.ToLocalTime() - result.LatestStage.CreatedDate).Days;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<LoanApplicationTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}