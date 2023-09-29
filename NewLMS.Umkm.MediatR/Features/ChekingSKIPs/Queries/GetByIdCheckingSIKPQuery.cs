using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ChekingSIKPs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ChekingSKIPs.Queries
{
    public class GetByIdCheckingSIKPQuery : IRequest<ServiceResponse<ChekingSIKPHistoryResponse>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdCheckingSIKPQueryHandler : IRequestHandler<GetByIdCheckingSIKPQuery, ServiceResponse<ChekingSIKPHistoryResponse>>
    {
        private IGenericRepositoryAsync<SIKPHistory> _core;
        private readonly IMapper _mapper;

        public GetByIdCheckingSIKPQueryHandler(IGenericRepositoryAsync<SIKPHistory> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ChekingSIKPHistoryResponse>> Handle(GetByIdCheckingSIKPQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "SIKPHistoryDetails",
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<ChekingSIKPHistoryResponse>.Return404("Data SIKP History tidak ditemukan.");
                var dataVm = _mapper.Map<ChekingSIKPHistoryResponse>(data);
                return ServiceResponse<ChekingSIKPHistoryResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ChekingSIKPHistoryResponse>.ReturnException(ex);
            }

        }
    }
}
