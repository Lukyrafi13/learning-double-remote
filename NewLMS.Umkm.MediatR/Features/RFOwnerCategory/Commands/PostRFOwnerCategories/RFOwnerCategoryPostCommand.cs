using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Commands
{
    public class RfOwnerCategoryPostCommand : RfOwnerCategoryPostRequestDto, IRequest<ServiceResponse<RfOwnerCategoryResponseDto>>
    {

    }
    public class PostRfOwnerCategoryCommandHandler : IRequestHandler<RfOwnerCategoryPostCommand, ServiceResponse<RfOwnerCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public PostRfOwnerCategoryCommandHandler(IGenericRepositoryAsync<RfOwnerCategory> rfOwnerCategory, IMapper mapper)
        {
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfOwnerCategoryResponseDto>> Handle(RfOwnerCategoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfOwnerCategory = new RfOwnerCategory();

                rfOwnerCategory.Active = true;
                rfOwnerCategory.OwnCode = request.OwnCode;
                rfOwnerCategory.OwnDesc = request.OwnDesc;
                rfOwnerCategory.CoreCode = request.CoreCode;

                var returnedRfStatusTarget = await _rfOwnerCategory.AddAsync(rfOwnerCategory, callSave: false);

                // var response = _mapper.Map<RfOwnerCategoryResponseDto>(returnedRfStatusTarget);
                var response = new RfOwnerCategoryResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.OwnCode = returnedRfStatusTarget.OwnCode;
                response.OwnDesc = returnedRfStatusTarget.OwnDesc;
                response.CoreCode = returnedRfStatusTarget.CoreCode;
                response.Active = returnedRfStatusTarget.Active;

                await _rfOwnerCategory.SaveChangeAsync();
                return ServiceResponse<RfOwnerCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfOwnerCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}