using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Commands
{
    public class SlikHistoryKreditDeleteCommand : SlikHistoryKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSlikHistoryKreditCommandHandler : IRequestHandler<SlikHistoryKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SlikHistoryKredit> _SlikHistoryKredit;
        private readonly IMapper _mapper;

        public DeleteSlikHistoryKreditCommandHandler(IGenericRepositoryAsync<SlikHistoryKredit> SlikHistoryKredit, IMapper mapper){
            _SlikHistoryKredit = SlikHistoryKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SlikHistoryKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SlikHistoryKredit.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SlikHistoryKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}