using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Commands
{
    public class SIKPHistoryDetailDeleteCommand : SIKPHistoryDetailFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSIKPHistoryDetailCommandHandler : IRequestHandler<SIKPHistoryDetailDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public DeleteSIKPHistoryDetailCommandHandler(IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, IMapper mapper){
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPHistoryDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SIKPHistoryDetail.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SIKPHistoryDetail.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}