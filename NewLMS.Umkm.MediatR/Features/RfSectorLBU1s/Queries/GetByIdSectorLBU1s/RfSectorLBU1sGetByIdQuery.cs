using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Queries
{
    public class RfSectorLBU1GetByIdQuery : IRequest<ServiceResponse<RfSectorLBU1Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRfSectorLBU1QueryHandler : IRequestHandler<RfSectorLBU1GetByIdQuery, ServiceResponse<RfSectorLBU1Response>>
    {
        private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetByIdRfSectorLBU1QueryHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSectorLBU1Response>> Handle(RfSectorLBU1GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfSectorLBU1.GetByIdAsync(request.Code, "Code");
                if (data == null)
                    return ServiceResponse<RfSectorLBU1Response>.Return404("Data RfSectorLBU1 not found");
                var dataVm = _mapper.Map<RfSectorLBU1Response>(data);
                return ServiceResponse<RfSectorLBU1Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfSectorLBU1Response>.ReturnException(ex);
            }

        }
    }
}
