using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Data.Dto.RfSectorLBU2s;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Queries
{
    public class RFSectorLBU2GetByIdQuery : IRequest<ServiceResponse<RfSectorLBU2Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU2QueryHandler : IRequestHandler<RFSectorLBU2GetByIdQuery, ServiceResponse<RfSectorLBU2Response>>
    {
        private IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU2QueryHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSectorLBU2Response>> Handle(RFSectorLBU2GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RfSectorLBU1" };
                var data = await _rfSectorLBU2.GetByIdAsync(request.Code, "Code", includes);
                if (data == null)
                    return ServiceResponse<RfSectorLBU2Response>.Return404("Data RFSectorLBU2 not found");
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
