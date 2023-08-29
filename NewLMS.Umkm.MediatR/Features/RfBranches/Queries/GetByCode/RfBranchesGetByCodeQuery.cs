using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranchess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBranchess.Queries
{
    public class RfBranchesGetByCodeQuery : RfBranchesFindRequestDto, IRequest<ServiceResponse<RfBranchesResponseDto>>
    {
    }

    public class GetByIdRfBranchesQueryHandler : IRequestHandler<RfBranchesGetByCodeQuery, ServiceResponse<RfBranchesResponseDto>>
    {
        private IGenericRepositoryAsync<RfBranches> _RfBranches;
        private readonly IMapper _mapper;

        public GetByIdRfBranchesQueryHandler(IGenericRepositoryAsync<RfBranches> RfBranches, IMapper mapper)
        {
            _RfBranch = RfBranches;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchesResponseDto>> Handle(RfBranchesGetByCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RfBranches.GetByIdAsync(request.Code, "Code");

            var response = new RfBranchesResponseDto();
            response.Code = data.Code;
            response.Name = data.Name;
            response.Dati = data.Dati;
            response.GroupBranch = data.GroupBranch;
            response.Kanwil = data.Kanwil;
            response.KanwilName = data.KanwilName;
            response.KanwilOri = data.KanwilOri;
            response.Kc = data.Kc;
            response.KcName = data.KcName;
            response.Kcp = data.Kcp;
            response.OfficeType = data.OfficeType;
            response.OriKanwilName = data.OriKanwilName;
            response.Sandi = data.Sandi;

            return ServiceResponse<RfBranchesResponseDto>.ReturnResultWith200(response);
        }
    }
}