using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Queries
{
    public class RFSectorLBU1GetByIdQuery : IRequest<ServiceResponse<RFSectorLBU1Response>>
    {
        public string Code { get; set; }
    }

    public class GetByIdRFSectorLBU1QueryHandler : IRequestHandler<RFSectorLBU1GetByIdQuery, ServiceResponse<RFSectorLBU1Response>>
    {
        private IGenericRepositoryAsync<RFSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetByIdRFSectorLBU1QueryHandler(IGenericRepositoryAsync<RFSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSectorLBU1Response>> Handle(RFSectorLBU1GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfSectorLBU1.GetByIdAsync(request.Code, "Code");
                if (data == null)
                    return ServiceResponse<RFSectorLBU1Response>.Return404("Data RFSectorLBU1 not found");
                var dataVm = _mapper.Map<RFSectorLBU1Response>(data);
                return ServiceResponse<RFSectorLBU1Response>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RFSectorLBU1Response>.ReturnException(ex);
            }

        }
    }
}
