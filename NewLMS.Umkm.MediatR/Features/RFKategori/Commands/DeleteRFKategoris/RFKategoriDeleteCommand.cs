using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCategorys.Commands
{
    public class RfCategoryDeleteCommand : RfCategoryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfCategoryCommandHandler : IRequestHandler<RfCategoryDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public DeleteRfCategoryCommandHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper){
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var RfCategory = await _RfCategory.GetByIdAsync(request.KategoriCode, "KategoriCode");
            RfCategory.IsDeleted = true;
            await _RfCategory.UpdateAsync(RfCategory);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}