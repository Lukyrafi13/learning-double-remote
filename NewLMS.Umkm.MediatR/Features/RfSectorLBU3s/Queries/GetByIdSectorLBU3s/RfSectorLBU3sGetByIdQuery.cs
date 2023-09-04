using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries
{
    public class RFSectorLBU3sGetByIdQuery : IRequest<ServiceResponse<RfSectorLBU3Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU3QueryHandler : IRequestHandler<RFSectorLBU3sGetByIdQuery, ServiceResponse<RfSectorLBU3Response>>
    {
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU3QueryHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSectorLBU3Response>> Handle(RFSectorLBU3sGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RfSectorLBU2", "RfSectorLBU2.RfSectorLBU1" };
                var data = await _rfSectorLBU3.GetByIdAsync(request.Code, "Code", includes);
                if (data == null)
                    return ServiceResponse<RfSectorLBU3Response>.Return404("Data RFSectorLBU3 not found");
                var dataVm = _mapper.Map<RfSectorLBU3Response>(data);
                return ServiceResponse<RfSectorLBU3Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfSectorLBU3Response>.ReturnException(ex);
            }

        }
    }
}
