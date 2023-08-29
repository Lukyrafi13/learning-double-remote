using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries
{
    public class RFSectorLBU3sGetByIdQuery : IRequest<ServiceResponse<RFSectorLBU3Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU3QueryHandler : IRequestHandler<RFSectorLBU3sGetByIdQuery, ServiceResponse<RFSectorLBU3Response>>
    {
        private IGenericRepositoryAsync<RFSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU3QueryHandler(IGenericRepositoryAsync<RFSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSectorLBU3Response>> Handle(RFSectorLBU3sGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RFSectorLBU2", "RFSectorLBU2.RFSectorLBU1" };
                var data = await _rfSectorLBU3.GetByIdAsync(request.Code, "Code", includes);
                if (data == null)
                    return ServiceResponse<RFSectorLBU3Response>.Return404("Data RFSectorLBU3 not found");
                var dataVm = _mapper.Map<RFSectorLBU3Response>(data);
                return ServiceResponse<RFSectorLBU3Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RFSectorLBU3Response>.ReturnException(ex);
            }

        }
    }
}
