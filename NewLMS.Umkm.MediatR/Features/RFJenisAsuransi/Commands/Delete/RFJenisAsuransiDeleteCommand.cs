using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisAsuransis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAsuransis.Commands
{
    public class RFJenisAsuransiDeleteCommand : RFJenisAsuransiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisAsuransiCommandHandler : IRequestHandler<RFJenisAsuransiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAsuransi> _RFJenisAsuransi;
        private readonly IMapper _mapper;

        public DeleteRFJenisAsuransiCommandHandler(IGenericRepositoryAsync<RFJenisAsuransi> RFJenisAsuransi, IMapper mapper){
            _RFJenisAsuransi = RFJenisAsuransi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisAsuransiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisAsuransi.GetByIdAsync(request.JenisCode, "JenisCode");
            rFProduct.IsDeleted = true;
            await _RFJenisAsuransi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}