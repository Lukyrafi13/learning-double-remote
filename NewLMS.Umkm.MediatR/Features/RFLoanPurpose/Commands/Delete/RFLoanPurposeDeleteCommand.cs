using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Commands
{
    public class RFLoanPurposeDeleteCommand : RFLoanPurposeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFLoanPurposeCommandHandler : IRequestHandler<RFLoanPurposeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private readonly IMapper _mapper;

        public DeleteRFLoanPurposeCommandHandler(IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose, IMapper mapper){
            _RFLoanPurpose = RFLoanPurpose;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFLoanPurposeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFLoanPurpose.GetByIdAsync(request.LP_CODE, "LP_CODE");
            rFProduct.IsDeleted = true;
            await _RFLoanPurpose.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}