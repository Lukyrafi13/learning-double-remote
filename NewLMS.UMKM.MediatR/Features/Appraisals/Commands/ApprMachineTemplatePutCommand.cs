using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalMachine;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands
{
    public class ApprMachineTemplatePutCommand : ApprMachineTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprMachineTemplatePutCommandHandler : IRequestHandler<ApprMachineTemplatePutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _appr;
        private readonly IMapper _mapper;

        public ApprMachineTemplatePutCommandHandler(IGenericRepositoryAsync<ApprMachineTemplate> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprMachineTemplatePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var datam = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (datam != null)
                {
                    datam.ObjectType = request.ObjectType;
                    datam.Manufacture = request.Manufacture;
                    datam.MachineNo = request.MachineNo;
                    datam.ChassisNo = request.ChassisNo;
                    datam.ObjectType = request.ObjectType;
                    datam.Capacity = request.Capacity;
                    datam.ProductionYear = request.ProductionYear;
                    datam.ManufacturerCountry = request.ManufacturerCountry;
                    datam.InvoiceNo = request.InvoiceNo;
                    datam.NameOnInvoice = request.NameOnInvoice;
                    datam.Storage = request.Storage;
                    datam.Size = request.Size;
                    datam.PhysicalCondition = request.PhysicalCondition;
                    datam.FunctionCondition = request.FunctionCondition;
                    datam.UsageTime = request.UsageTime;
                    datam.Installation = request.Installation;

                    datam.LastServiceDate = request.LastServiceDate;
                    datam.Overhaul = request.Overhaul;
                    datam.Address = request.Address;
                    datam.Rt = request.Rt;
                    datam.Rw = request.Rw;
                    datam.WilayahVillageCode = request.AddressReference;
                    datam.PeriodicService = request.PeriodicService;
                    datam.InspectionDate = request.InspectionDate;
                    datam.Remarks = request.Remarks;
                    datam.ModifiedDate = DateTime.Now;
                    await _appr.UpdateAsync(datam);
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
