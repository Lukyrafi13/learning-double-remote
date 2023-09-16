﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetApprBuildingTemplateQuery : IRequest<ServiceResponse<ApprBuildingTemplateResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprBuildingTemplateQueryHandler : IRequestHandler<GetApprBuildingTemplateQuery, ServiceResponse<ApprBuildingTemplateResponse>>
    {
        private IGenericRepositoryAsync<ApprBuildingTemplates> _ApprBuildingTemplate;
        private IMapper _mapper;

        public GetApprBuildingTemplateQueryHandler(IGenericRepositoryAsync<ApprBuildingTemplates> ApprBuildingTemplate, IMapper mapper)
        {
            _ApprBuildingTemplate = ApprBuildingTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprBuildingTemplateResponse>> Handle(GetApprBuildingTemplateQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprBuildingTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid", new string[] {
                "FoundationFK",
                "WallFK",
                "FloorFK",
                "RoofTrussFK",
                "RoofFK",
                "PlafondFK",
                "InnerWallFK",
                "SillsFK",
                "ElectricConnFK",
                "CleanWaterFK",
                "PhoneFK",
                "ArchitectShapeFK",
                "BuildingConditionFK",
                "YardConditionFK",
                "FenceFK",
                "ApprBuildingFloors",
                "Appraisals.DebtorCollaterals.Debtors"
            });
            var dataVm = _mapper.Map<ApprBuildingTemplateResponse>(data);

            if (data != null && data.ApprBuildingFloors != null && data.ApprBuildingFloors.Count > 0)
            {
                var totalArea = data.ApprBuildingFloors.Select(x => x.TotalArea);
                if (totalArea != null)
                {
                    dataVm.RealMeasuringArea = totalArea.Sum();
                }
            }

            return ServiceResponse<ApprBuildingTemplateResponse>.ReturnResultWith200(dataVm);
        }
    }
}
