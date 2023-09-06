using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands

{
    public class ProspectPostCommand : ProspectPostRequest, IRequest<ServiceResponse<Guid>>
    {

    }
    public class PostProspectCommandHandler : IRequestHandler<ProspectPostCommand, ServiceResponse<Guid>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<RfProduct> _product;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IGenericRepositoryAsync<RfGender> _gender;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParamterDetail;
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _subSubSector;
        private readonly IGenericRepositoryAsync<RfBranch> _branch;
        private readonly IMapper _mapper;


        public PostProspectCommandHandler(
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

        public async Task<ServiceResponse<Guid>> Handle(ProspectPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _product.GetByIdAsync(request.ProductId, "ProductId");

                var countDataProspect = await _prospect.GetCountByPredicate(x =>
                            x.CreatedDate.Year == DateTime.Now.Year
                            && x.CreatedDate.Month == DateTime.Now.Month
                            );
                // Build ProspectId
                var prospectId = request.BranchId
                            + "-"
                            + product.ProductType
                            + "-"
                            + DateTime.Now.ToString("yy")
                            + DateTime.Now.ToString("MM")
                            + "-"
                            + (countDataProspect + 1).ToString("D4");

                var prospect = _mapper.Map<Prospect>(request);
                prospect.ProspectId = prospectId;

                await _prospect.AddAsync(prospect);
                return ServiceResponse<Guid>.ReturnResultWith201(prospect.Id);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<Guid>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}