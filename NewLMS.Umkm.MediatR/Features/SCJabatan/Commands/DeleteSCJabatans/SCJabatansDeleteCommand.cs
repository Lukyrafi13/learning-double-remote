using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SCJabatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SCJabatans.Commands
{
    public class SCJabatanDeleteCommand : SCJabatanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteSCJabatanCommandHandler : IRequestHandler<SCJabatanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SCJabatan> _sCJabatan;
        private readonly IMapper _mapper;

        public DeleteSCJabatanCommandHandler(IGenericRepositoryAsync<SCJabatan> SCJabatan, IMapper mapper)
        {
            _sCJabatan = SCJabatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SCJabatanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _sCJabatan.GetByIdAsync(request.JAB_CODE, "JAB_CODE");
            rFProduct.IsDeleted = true;
            await _sCJabatan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}