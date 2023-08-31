using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Commands
{
    public class SIKPResponseDataDeleteCommand : SIKPResponseDataFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSIKPResponseDataCommandHandler : IRequestHandler<SIKPResponseDataDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IMapper _mapper;

        public DeleteSIKPResponseDataCommandHandler(IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData, IMapper mapper){
            _SIKPResponseData = SIKPResponseData;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPResponseDataDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SIKPResponseData.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SIKPResponseData.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}