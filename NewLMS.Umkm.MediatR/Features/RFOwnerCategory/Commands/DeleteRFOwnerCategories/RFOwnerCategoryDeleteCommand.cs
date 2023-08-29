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
    public class RfOwnerCategoryDeleteCommand : RfOwnerCategoryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfOwnerCategoryCommandHandler : IRequestHandler<RfOwnerCategoryDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public DeleteRfOwnerCategoryCommandHandler(IGenericRepositoryAsync<RfOwnerCategory> rfOwnerCategory, IMapper mapper){
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfOwnerCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfOwnerCategory = await _rfOwnerCategory.GetByIdAsync(request.OwnCode, "OwnCode");
            rfOwnerCategory.IsDeleted = true;
            await _rfOwnerCategory.UpdateAsync(rfOwnerCategory);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}