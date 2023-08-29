using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Commands
{
    public class RFOwnerCategoryPostCommand : RFOwnerCategoryPostRequestDto, IRequest<ServiceResponse<RFOwnerCategoryResponseDto>>
    {

    }
    public class PostRFOwnerCategoryCommandHandler : IRequestHandler<RFOwnerCategoryPostCommand, ServiceResponse<RFOwnerCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public PostRFOwnerCategoryCommandHandler(IGenericRepositoryAsync<RFOwnerCategory> rfOwnerCategory, IMapper mapper)
        {
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFOwnerCategoryResponseDto>> Handle(RFOwnerCategoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfOwnerCategory = new RFOwnerCategory();

                rfOwnerCategory.Active = true;
                rfOwnerCategory.OwnCode = request.OwnCode;
                rfOwnerCategory.OwnDesc = request.OwnDesc;
                rfOwnerCategory.CoreCode = request.CoreCode;

                var returnedRfStatusTarget = await _rfOwnerCategory.AddAsync(rfOwnerCategory, callSave: false);

                // var response = _mapper.Map<RFOwnerCategoryResponseDto>(returnedRfStatusTarget);
                var response = new RFOwnerCategoryResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.OwnCode = returnedRfStatusTarget.OwnCode;
                response.OwnDesc = returnedRfStatusTarget.OwnDesc;
                response.CoreCode = returnedRfStatusTarget.CoreCode;
                response.Active = returnedRfStatusTarget.Active;

                await _rfOwnerCategory.SaveChangeAsync();
                return ServiceResponse<RFOwnerCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFOwnerCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}