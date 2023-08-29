using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTipeKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTipeKredits.Commands
{
    public class RFTipeKreditDeleteCommand : RFTipeKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFTipeKreditCommandHandler : IRequestHandler<RFTipeKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTipeKredit> _RFTipeKredit;
        private readonly IMapper _mapper;

        public DeleteRFTipeKreditCommandHandler(IGenericRepositoryAsync<RFTipeKredit> RFTipeKredit, IMapper mapper){
            _RFTipeKredit = RFTipeKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTipeKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTipeKredit.GetByIdAsync(request.Code, "Code");
            rFProduct.IsDeleted = true;
            await _RFTipeKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}