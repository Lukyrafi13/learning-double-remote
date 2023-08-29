using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Queries
{
    public class RfSectorLBU2GetByIdQuery : IRequest<ServiceResponse<RfSectorLBU2Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRfSectorLBU2QueryHandler : IRequestHandler<RfSectorLBU2GetByIdQuery, ServiceResponse<RfSectorLBU2Response>>
    {
        private IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public GetByIdRfSectorLBU2QueryHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSectorLBU2Response>> Handle(RfSectorLBU2GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RfSectorLBU1" };
                var data = await _rfSectorLBU2.GetByIdAsync(request.Code, "Code", includes);
                if (data == null)
                    return ServiceResponse<RfSectorLBU2Response>.Return404("Data RfSectorLBU2 not found");
                var dataVm = _mapper.Map<RfSectorLBU2Response>(data);
                return ServiceResponse<RfSectorLBU2Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfSectorLBU2Response>.ReturnException(ex);
            }

        }
    }
}
