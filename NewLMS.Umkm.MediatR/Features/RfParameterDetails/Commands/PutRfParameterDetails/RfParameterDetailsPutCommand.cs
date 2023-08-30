using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PutRfParameterDetails
{
    public class RfParameterDetailPutCommand : RfParameterDetailPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRfParameterDetailCommandHandler : IRequestHandler<RfParameterDetailPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly IMapper _mapper;

        public PutRfParameterDetailCommandHandler(IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail, IMapper mapper)
        {
            _rfParameterDetail = rfParameterDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterDetailPutCommand request, CancellationToken cancellationToken)
        {
            var rfParameterDetail = await _rfParameterDetail.GetByIdAsync(request.ParameterDetailId, "ParameterDetailId");

            rfParameterDetail.ParameterId = request.ParameterId;
            rfParameterDetail.Code = request.Code;
            rfParameterDetail.Name = request.Name;
            rfParameterDetail.Description = request.Description;
            rfParameterDetail.Order = request.Order;
            rfParameterDetail.Active = request.Active;

            await _rfParameterDetail.UpdateAsync(rfParameterDetail);

            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
