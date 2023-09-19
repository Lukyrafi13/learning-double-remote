using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalMachine;
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
    public class ApprMachineTemplatePostCommand : ApprMachineTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprMachineTemplatePostCommandHandler : IRequestHandler<ApprMachineTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _appr;
        private readonly IMapper _mapper;

        public ApprMachineTemplatePostCommandHandler(IGenericRepositoryAsync<ApprMachineTemplate> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprMachineTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprEntity = new ApprMachineTemplate
                {
                    ApprMachineTemplateGuid = Guid.NewGuid(),
                    AppraisalGuid = request.AppraisalGuid,
                    ObjectType = request.ObjectType,
                    Manufacture = request.Manufacture,
                    MachineNo = request.MachineNo,
                    ChassisNo = request.ChassisNo,
                    Capacity = request.Capacity,
                    ProductionYear = request.ProductionYear,
                    ManufacturerCountry = request.ManufacturerCountry,
                    InvoiceNo = request.InvoiceNo,
                    NameOnInvoice = request.NameOnInvoice,
                    Storage = request.Storage,
                    Size = request.Size,
                    PhysicalCondition = request.PhysicalCondition,
                    FunctionCondition = request.FunctionCondition,
                    UsageTime = request.UsageTime,
                    Installation = request.Installation,

                    LastServiceDate = request.LastServiceDate,
                    Overhaul = request.Overhaul,
                    Address = request.Address,
                    Rt = request.Rt,
                    Rw = request.Rw,
                    WilayahVillageCode = request.AddressReference,
                    PeriodicService = request.PeriodicService,
                    InspectionDate = request.InspectionDate,
                    Remarks = request.Remarks

                };
                await _appr.AddAsync(apprEntity);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
