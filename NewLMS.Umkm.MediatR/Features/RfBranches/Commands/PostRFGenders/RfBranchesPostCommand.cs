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
    public class RfBranchesPostCommand : RfBranchesPostRequestDto, IRequest<ServiceResponse<RfBranchesResponseDto>>
    {

    }
    public class PostRfBranchesCommandHandler : IRequestHandler<RfBranchesPostCommand, ServiceResponse<RfBranchesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBranches> _RfBranches;
        private readonly IMapper _mapper;

        public PostRfBranchesCommandHandler(IGenericRepositoryAsync<RfBranches> RfBranches, IMapper mapper)
        {
            _RfBranches = RfBranches;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchesResponseDto>> Handle(RfBranchesPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfBranches = new RfBranches();

                RfBranches.Code = request.Code;
                RfBranches.Name = request.Name;
                RfBranches.Dati = request.Dati;
                RfBranches.GroupBranch = request.GroupBranch;
                RfBranches.Kanwil = request.Kanwil;
                RfBranches.KanwilName = request.KanwilName;
                RfBranches.KanwilOri = request.Kanwil;
                RfBranches.Kc = request.Kc;
                RfBranches.KcName = request.KcName;
                RfBranches.Kcp = request.Kcp;
                RfBranches.OfficeType = request.OfficeType;
                RfBranches.OriKanwilName = request.Kcp;
                RfBranches.Sandi = request.Sandi;

                var returnedRfStatusTarget = await _RfBranches.AddAsync(RfBranches, callSave: false);

                var response = _mapper.Map<RfBranchesResponseDto>(returnedRfStatusTarget);

                response.Code = returnedRfStatusTarget.Code;
                response.Name = returnedRfStatusTarget.Name;
                response.Dati = returnedRfStatusTarget.Dati;
                response.GroupBranch = returnedRfStatusTarget.GroupBranch;
                response.Kanwil = returnedRfStatusTarget.Kanwil;
                response.KanwilName = returnedRfStatusTarget.KanwilName;
                response.KanwilOri = returnedRfStatusTarget.KanwilOri;
                response.Kc = returnedRfStatusTarget.Kc;
                response.KcName = returnedRfStatusTarget.KcName;
                response.Kcp = returnedRfStatusTarget.Kcp;
                response.OfficeType = returnedRfStatusTarget.OfficeType;
                response.OriKanwilName = returnedRfStatusTarget.OriKanwilName;
                response.Sandi = returnedRfStatusTarget.Sandi;
                await _RfBranches.SaveChangeAsync();
                return ServiceResponse<RfBranchesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBranchesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}