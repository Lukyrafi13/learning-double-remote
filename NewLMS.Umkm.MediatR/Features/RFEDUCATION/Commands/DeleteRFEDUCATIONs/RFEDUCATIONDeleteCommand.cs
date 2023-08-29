using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Commands
{
    public class RFEDUCATIONDeleteCommand : RFEDUCATIONFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFEDUCATIONCommandHandler : IRequestHandler<RFEDUCATIONDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private readonly IMapper _mapper;

        public DeleteRFEDUCATIONCommandHandler(IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION, IMapper mapper)
        {
            _RFEDUCATION = RFEDUCATION;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFEDUCATIONDeleteCommand request, CancellationToken cancellationToken)
        {
            var RFEDUCATION = await _RFEDUCATION.GetByIdAsync(request.ED_CODE, "ED_CODE");
            RFEDUCATION.IsDeleted = true;
            await _RFEDUCATION.UpdateAsync(RFEDUCATION);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}