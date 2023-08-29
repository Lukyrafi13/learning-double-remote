using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBranches.Queries
{
    public class RfBranchGetByCodeQuery : RfBranchFindRequestDto, IRequest<ServiceResponse<RfBranchResponseDto>>
    {
    }

    public class RfBranchGetByCodeQueryHandler : IRequestHandler<RfBranchGetByCodeQuery, ServiceResponse<RfBranchResponseDto>>
    {
        private IGenericRepositoryAsync<RfBranch> _RfBranch;
        private readonly IMapper _mapper;

        public RfBranchGetByCodeQueryHandler(IGenericRepositoryAsync<RfBranch> RfBranch, IMapper mapper)
        {
            _RfBranch = RfBranch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchResponseDto>> Handle(RfBranchGetByCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RfBranch.GetByIdAsync(request.Code, "Code");

            var response = new RfBranchResponseDto();
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

            return ServiceResponse<RfBranchResponseDto>.ReturnResultWith200(response);
        }
    }
}