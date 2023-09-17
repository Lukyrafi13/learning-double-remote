using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalMachine;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetApprMachineTemplateQuery : IRequest<ServiceResponse<ApprMachineTemplateResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprMachineTemplateQueryHandler : IRequestHandler<GetApprMachineTemplateQuery, ServiceResponse<ApprMachineTemplateResponse>>
    {
        private IGenericRepositoryAsync<ApprMachineTemplate> _ApprMachineTemplate;
        private IMapper _mapper;

        public GetApprMachineTemplateQueryHandler(IGenericRepositoryAsync<ApprMachineTemplate> ApprMachineTemplate, IMapper mapper)
        {
            _ApprMachineTemplate = ApprMachineTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprMachineTemplateResponse>> Handle(GetApprMachineTemplateQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprMachineTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid",
            new string[] {
                "WilayahVillages",
                "WilayahVillages.WilayahDistricts",
                "WilayahVillages.WilayahDistricts.WilayahRegencies",
                "WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces"
            });
            var dataVm = _mapper.Map<ApprMachineTemplateResponse>(data);

            return ServiceResponse<ApprMachineTemplateResponse>.ReturnResultWith200(dataVm);
        }
    }
}
