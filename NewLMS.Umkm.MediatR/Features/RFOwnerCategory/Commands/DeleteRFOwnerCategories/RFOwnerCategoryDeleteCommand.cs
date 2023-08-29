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
    public class RFOwnerCategoryDeleteCommand : RFOwnerCategoryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFOwnerCategoryCommandHandler : IRequestHandler<RFOwnerCategoryDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public DeleteRFOwnerCategoryCommandHandler(IGenericRepositoryAsync<RFOwnerCategory> rfOwnerCategory, IMapper mapper){
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFOwnerCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfOwnerCategory = await _rfOwnerCategory.GetByIdAsync(request.OwnCode, "OwnCode");
            rfOwnerCategory.IsDeleted = true;
            await _rfOwnerCategory.UpdateAsync(rfOwnerCategory);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}