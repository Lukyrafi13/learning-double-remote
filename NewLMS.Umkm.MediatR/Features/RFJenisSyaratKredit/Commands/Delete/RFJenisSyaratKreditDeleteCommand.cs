using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisSyaratKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisSyaratKredits.Commands
{
    public class RFJenisSyaratKreditDeleteCommand : RFJenisSyaratKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisSyaratKreditCommandHandler : IRequestHandler<RFJenisSyaratKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisSyaratKredit> _RFJenisSyaratKredit;
        private readonly IMapper _mapper;

        public DeleteRFJenisSyaratKreditCommandHandler(IGenericRepositoryAsync<RFJenisSyaratKredit> RFJenisSyaratKredit, IMapper mapper){
            _RFJenisSyaratKredit = RFJenisSyaratKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisSyaratKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisSyaratKredit.GetByIdAsync(request.SyaratCode, "SyaratCode");
            rFProduct.IsDeleted = true;
            await _RFJenisSyaratKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}