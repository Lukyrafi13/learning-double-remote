using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.UMKM.Data.Entities;
using ClosedXML.Excel.CalcEngine.Exceptions;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands

{
    public class ProspectPutCommand : ProspectPutRequest, IRequest<ServiceResponse<Unit>>
    {

    }
    public class PutProspectCommandHandler : IRequestHandler<ProspectPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<RfProduct> _product;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IGenericRepositoryAsync<RfGender> _gender;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParamterDetail;
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _subSubSector;
        private readonly IGenericRepositoryAsync<RfBranch> _branch;
        private readonly IMapper _mapper;


        public PutProspectCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<RfZipCode> zipCode,
                IGenericRepositoryAsync<RfProduct> product,
                IGenericRepositoryAsync<RfGender> gender,
                IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail,
                IGenericRepositoryAsync<RfSectorLBU3> subSubSector,
                IGenericRepositoryAsync<RfBranch> branch,
                IMapper mapper
        )
        {
            _prospect = prospect;
            _zipCode = zipCode;
            _gender = gender;
            _rfParamterDetail = rfParameterDetail;
            _mapper = mapper;
            _branch = branch;
            _product = product;
        }

        public async Task<ServiceResponse<Unit>> Handle(ProspectPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var prospectIncludes = new string[]
                {
                    "RfProduct"
                };
                var prospect = await _prospect.GetByIdAsync(request.Id, "Id", prospectIncludes)
                    ?? throw new NullReferenceException("Data Prospect tidak ditemukan.");

                var product = await _product.GetByIdAsync(request.ProductId, "ProductId")
                    ?? throw new NullReferenceException("Data Produk tidak ditemukan.");

                // Build ProspectId If Product Changed
                if (prospect.BranchId != request.BranchId)
                {
                    var countDataProspect = await _prospect.GetCountByPredicate(x =>
                                x.BranchId == request.BranchId
                                && x.RfProduct.ProductType == product.ProductType
                                && x.CreatedDate.Year == DateTime.Now.Year
                                && x.CreatedDate.Month == DateTime.Now.Month
                                );
                    prospect.ProspectId = request.BranchId
                                + "-"
                                + product.ProductType
                                + "-"
                                + DateTime.Now.ToString("yy")
                                + DateTime.Now.ToString("MM")
                                + "-"
                                + (countDataProspect + 1).ToString("D4");
                }
                prospect = _mapper.Map<ProspectPutRequest, Prospect>(request, prospect);

                await _prospect.UpdateAsync(prospect);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}