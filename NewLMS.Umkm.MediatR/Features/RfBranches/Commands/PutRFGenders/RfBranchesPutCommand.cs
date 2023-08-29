using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfBranchess;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RfBranchess.Commands
{
    public class RfBranchesPutCommand : RfBranchesPutRequestDto, IRequest<ServiceResponse<RfBranchesResponseDto>>
    {
    }

    public class PutRfBranchesCommandHandler : IRequestHandler<RfBranchesPutCommand, ServiceResponse<RfBranchesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBranches> _RfBranches;
        private readonly IMapper _mapper;

        public PutRfBranchesCommandHandler(IGenericRepositoryAsync<RfBranches> RfBranches, IMapper mapper){
            _RfBranches = RfBranches;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchesResponseDto>> Handle(RfBranchesPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfBranches = await _RfBranches.GetByIdAsync(request.Code, "Code");
                existingRfBranches.Code = request.Code;
                existingRfBranches.Name = request.Name;
                existingRfBranches.Dati = request.Dati;
                existingRfBranches.GroupBranch = request.GroupBranch;
                existingRfBranches.Kanwil = request.Kanwil;
                existingRfBranches.KanwilName = request.KanwilName;
                existingRfBranches.KanwilOri = request.KanwilOri;
                existingRfBranches.Kc = request.Kc;
                existingRfBranches.KcName = request.KcName;
                existingRfBranches.Kcp = request.Kcp;
                existingRfBranches.OfficeType = request.OfficeType;
                existingRfBranches.OriKanwilName = request.OriKanwilName;
                existingRfBranches.Sandi = request.Sandi;
                
                await _RfBranches.UpdateAsync(existingRfBranches);

                var response = _mapper.Map<RfBranchesResponseDto>(existingRfBranches);

                return ServiceResponse<RfBranchesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBranchesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}