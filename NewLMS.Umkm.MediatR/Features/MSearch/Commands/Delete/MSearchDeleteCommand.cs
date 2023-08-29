using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.MSearchs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.MSearchs.Commands
{
    public class MSearchDeleteCommand : MSearchFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteMSearchCommandHandler : IRequestHandler<MSearchDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<MSearch> _MSearch;
        private readonly IMapper _mapper;

        public DeleteMSearchCommandHandler(IGenericRepositoryAsync<MSearch> MSearch, IMapper mapper){
            _MSearch = MSearch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(MSearchDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _MSearch.GetByIdAsync(request.TypeId, "TypeId");
            rFProduct.IsDeleted = true;
            await _MSearch.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}