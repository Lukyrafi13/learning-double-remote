using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLnkPertumbuhans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands
{
    public class RFApprTanahLnkPertumbuhanDeleteCommand : RFApprTanahLnkPertumbuhanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFApprTanahLnkPertumbuhanCommandHandler : IRequestHandler<RFApprTanahLnkPertumbuhanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> _RFApprTanahLnkPertumbuhan;
        private readonly IMapper _mapper;

        public DeleteRFApprTanahLnkPertumbuhanCommandHandler(IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> RFApprTanahLnkPertumbuhan, IMapper mapper)
        {
            _RFApprTanahLnkPertumbuhan = RFApprTanahLnkPertumbuhan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFApprTanahLnkPertumbuhanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFApprTanahLnkPertumbuhan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
            rFProduct.IsDeleted = true;
            await _RFApprTanahLnkPertumbuhan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}