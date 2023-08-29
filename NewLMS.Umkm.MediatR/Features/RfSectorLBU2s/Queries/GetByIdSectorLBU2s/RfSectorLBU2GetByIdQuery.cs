using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Queries
{
    public class RFSectorLBU2GetByIdQuery : IRequest<ServiceResponse<RFSectorLBU2Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU2QueryHandler : IRequestHandler<RFSectorLBU2GetByIdQuery, ServiceResponse<RFSectorLBU2Response>>
    {
        private IGenericRepositoryAsync<RFSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU2QueryHandler(IGenericRepositoryAsync<RFSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSectorLBU2Response>> Handle(RFSectorLBU2GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RFSectorLBU1" };
                var data = await _rfSectorLBU2.GetByIdAsync(request.Code, "Code", includes);
                if (data == null)
                    return ServiceResponse<RFSectorLBU2Response>.Return404("Data RFSectorLBU2 not found");
                var dataVm = _mapper.Map<RFSectorLBU2Response>(data);
                return ServiceResponse<RFSectorLBU2Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RFSectorLBU2Response>.ReturnException(ex);
            }

        }
    }
}
