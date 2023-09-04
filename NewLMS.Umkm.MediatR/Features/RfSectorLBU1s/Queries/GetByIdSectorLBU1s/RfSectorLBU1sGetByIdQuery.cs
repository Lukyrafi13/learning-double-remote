using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Queries
{
    public class RFSectorLBU1GetByIdQuery : IRequest<ServiceResponse<RfSectorLBU1Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU1QueryHandler : IRequestHandler<RFSectorLBU1GetByIdQuery, ServiceResponse<RfSectorLBU1Response>>
    {
        private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU1QueryHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSectorLBU1Response>> Handle(RFSectorLBU1GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfSectorLBU1.GetByIdAsync(request.Code, "Code");
                if (data == null)
                    return ServiceResponse<RfSectorLBU1Response>.Return404("Data RFSectorLBU1 not found");
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
