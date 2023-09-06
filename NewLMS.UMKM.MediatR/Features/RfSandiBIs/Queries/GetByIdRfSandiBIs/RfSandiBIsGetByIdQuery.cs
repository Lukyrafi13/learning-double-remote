using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSandiBI;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSandiBIs.Queries.GetByIdRfSandiBIs
{
    public class RfSandiBIsGetByIdQuery : IRequest<ServiceResponse<RfSandiBIResponse>>
    {
        public string RfSandiBIId { get; set; }
    }

    public class RfSandiBIsGetByIdQueryHandler : IRequestHandler<RfSandiBIsGetByIdQuery, ServiceResponse<RfSandiBIResponse>>
    {
        private IGenericRepositoryAsync<RfSandiBI> _core;
        private readonly IMapper _mapper;

        public RfSandiBIsGetByIdQueryHandler(IGenericRepositoryAsync<RfSandiBI> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSandiBIResponse>> Handle(RfSandiBIsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RfSandiBIGroup" };
                var data = await _core.GetByIdAsync(request.RfSandiBIId, "RfSandiBIId", includes);
                if (data == null)
                    return ServiceResponse<RfSandiBIResponse>.Return404("Data RfSandiBI not found");
                var dataVm = _mapper.Map<RfSandiBIResponse>(data);
                return ServiceResponse<RfSandiBIResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfSandiBIResponse>.ReturnException(ex);
            }

        }
    }
}
