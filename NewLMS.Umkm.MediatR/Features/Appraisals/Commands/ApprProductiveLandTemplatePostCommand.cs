using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalProductiveLands;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands
{
    public class ApprProductiveLandTemplatePostCommand : ApprProductiveLandTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprProductiveLandTemplatePostCommandHandler : IRequestHandler<ApprProductiveLandTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprProductiveLandTemplate> _appr;
        private readonly IMapper _mapper;

        public ApprProductiveLandTemplatePostCommandHandler(IGenericRepositoryAsync<ApprProductiveLandTemplate> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprProductiveLandTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataLand = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (dataLand == null)
                {
                    var apprEntity = new ApprProductiveLandTemplate
                    {
                        ApprProductiveLandTemplateGuid = Guid.NewGuid(),
                        AppraisalGuid = request.AppraisalGuid,
                        Inhabited = request.Inhabited,
                        ObjectType = request.ObjectType,
                        InspectionDate = request.InspectionDate,
                        CollateralOwner = request.CollateralOwner,
                        InhabitedBy = request.InhabitedBy,
                        IsHaveBuilding = request.IsHaveBuilding,
                        Electric = request.Electric,
                        CleanWater = request.CleanWater,
                        Phone = request.Phone,
                        Gas = request.Gas,
                        GarbageCollection = request.GarbageCollection,
                        Irrigation = request.Irrigation,
                        Entrance = request.Entrance,
                        Driveway = request.Driveway,
                        Drainase = request.Drainase,
                        NorthernBoundary = request.NorthernBoundary,
                        SouthernBoundary = request.SouthernBoundary,
                        WesternBoundary = request.WesternBoundary,
                        EasternBoundary = request.EasternBoundary,

                        EnvLocation = request.EnvLocation,
                        EnvGrowth = request.EnvGrowth,
                        EnvDensity = request.EnvDensity,
                        EnvEaseOfAccess = request.EnvEaseOfAccess,
                        EnvComodity = request.EnvComodity,
                        EnvWaterFacilities = request.EnvWaterFacilities,
                        EnvTransport = request.EnvTransport,
                        EnvWaterQuality = request.EnvWaterQuality,
                        EnvDisasterSafety = request.EnvDisasterSafety,

                        CertficateNumber = request.CertficateNumber,
                        RegisteredName = request.RegisteredName,
                        IssuedDate = request.IssuedDate,
                        MeasureLetterNo = request.MeasureLetterNo,
                        MeasureLetterDate = request.MeasureLetterDate,
                        LandShape = request.LandShape,
                        LandAreaValue = request.LandAreaValue,
                        Address = request.Address,
                        ZipCodeId = request.ZipCodeId,
                        Rt = request.Rt,
                        Rw = request.Rw,
                        Topografi = request.Topografi,
                        LandType = request.LandType,
                        Greening = request.Greening,
                        Arrangement = request.Arrangement,
                        WaterDisposal = request.WaterDisposal,
                        FloodRisk = request.FloodRisk,
                        FireRisk = request.FireRisk,
                        LandHeight = request.LandHeight,
                        HighVoltage = request.HighVoltage,
                        LandWidth = request.LandWidth,
                        LandLength = request.LandLength,
                        PublicBurial = request.PublicBurial,
                        Remarks = request.Remarks,

                        ElectricNetwork = request.ElectricNetwork,
                        EnvRoad = request.EnvRoad,
                        EnvCertificateType = request.EnvCertificateType,
                        EnvPublicBurial = request.EnvPublicBurial,
                        Residential = request.Residential,
                        Farm = request.Farm,
                        Plantation = request.Plantation,
                        Empty = request.Empty,
                        ValidUntil = request.ValidUntil,
                        Lifetime = request.Lifetime,
                        EnvDrainase = request.EnvDrainase,
                        EnvChangesFutureUse = request.EnvChangesFutureUse,
                        EnvMajorityOwnership = request.EnvMajorityOwnership,
                        EnvEntrance = request.EnvEntrance,
                        GarbageCollectionDistance = request.GarbageCollectionDistance,
                        Skewer = request.Skewer
                    };
                    await _appr.AddAsync(apprEntity);

                }
                else
                {
                    dataLand.Electric = request.Electric;
                    dataLand.CleanWater = request.CleanWater;
                    dataLand.Phone = request.Phone;
                    dataLand.Gas = request.Gas;
                    dataLand.Inhabited = request.Inhabited;
                    dataLand.ObjectType = request.ObjectType;
                    dataLand.InspectionDate = request.InspectionDate;
                    dataLand.CollateralOwner = request.CollateralOwner;
                    dataLand.InhabitedBy = request.InhabitedBy;
                    dataLand.IsHaveBuilding = request.IsHaveBuilding;
                    dataLand.GarbageCollection = request.GarbageCollection;
                    dataLand.Irrigation = request.Irrigation;
                    dataLand.Entrance = request.Entrance;
                    dataLand.Driveway = request.Driveway;
                    dataLand.Drainase = request.Drainase;
                    dataLand.NorthernBoundary = request.NorthernBoundary;
                    dataLand.SouthernBoundary = request.SouthernBoundary;
                    dataLand.WesternBoundary = request.WesternBoundary;
                    dataLand.EasternBoundary = request.EasternBoundary;

                    dataLand.EnvLocation = request.EnvLocation;
                    dataLand.EnvGrowth = request.EnvGrowth;
                    dataLand.EnvDensity = request.EnvDensity;
                    dataLand.EnvEaseOfAccess = request.EnvEaseOfAccess;
                    dataLand.EnvTransport = request.EnvTransport;
                    dataLand.EnvDisasterSafety = request.EnvDisasterSafety;
                    dataLand.EnvComodity = request.EnvComodity;
                    dataLand.EnvWaterFacilities = request.EnvWaterFacilities;
                    dataLand.EnvWaterQuality = request.EnvWaterQuality;

                    dataLand.CertficateNumber = request.CertficateNumber;
                    dataLand.RegisteredName = request.RegisteredName;
                    dataLand.IssuedDate = request.IssuedDate;
                    dataLand.MeasureLetterNo = request.MeasureLetterNo;
                    dataLand.MeasureLetterDate = request.MeasureLetterDate;
                    dataLand.LandShape = request.LandShape;
                    dataLand.LandAreaValue = request.LandAreaValue;
                    dataLand.Address = request.Address;
                    dataLand.ZipCodeId = request.ZipCodeId;
                    dataLand.Rt = request.Rt;
                    dataLand.Rw = request.Rw;
                    dataLand.Topografi = request.Topografi;
                    dataLand.LandType = request.LandType;
                    dataLand.Greening = request.Greening;
                    dataLand.Arrangement = request.Arrangement;
                    dataLand.WaterDisposal = request.WaterDisposal;
                    dataLand.FloodRisk = request.FloodRisk;
                    dataLand.FireRisk = request.FireRisk;
                    dataLand.LandHeight = request.LandHeight;
                    dataLand.HighVoltage = request.HighVoltage;
                    dataLand.LandWidth = request.LandWidth;
                    dataLand.LandLength = request.LandLength;
                    dataLand.PublicBurial = request.PublicBurial;
                    dataLand.ElectricNetwork = request.ElectricNetwork;
                    dataLand.EnvRoad = request.EnvRoad;
                    dataLand.EnvCertificateType = request.EnvCertificateType;
                    dataLand.EnvPublicBurial = request.EnvPublicBurial;
                    dataLand.Residential = request.Residential;
                    dataLand.Farm = request.Farm;
                    dataLand.Plantation = request.Plantation;
                    dataLand.Empty = request.Empty;
                    dataLand.ValidUntil = request.ValidUntil;
                    dataLand.Lifetime = request.Lifetime;
                    dataLand.EnvDrainase = request.EnvDrainase;
                    dataLand.EnvChangesFutureUse = request.EnvChangesFutureUse;
                    dataLand.EnvMajorityOwnership = request.EnvMajorityOwnership;
                    dataLand.EnvEntrance = request.EnvEntrance;
                    dataLand.GarbageCollectionDistance = request.GarbageCollectionDistance;
                    dataLand.Skewer = request.Skewer;
                    dataLand.ModifiedDate = DateTime.Now;
                    await _appr.UpdateAsync(dataLand);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
