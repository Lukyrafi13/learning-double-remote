using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBranches.Commands
{
    public class RfBranchPostCommand : RfBranchPostRequestDto, IRequest<ServiceResponse<RfBranchResponseDto>>
    {

    }
    public class RfBranchPostCommandHandler : IRequestHandler<RfBranchPostCommand, ServiceResponse<RfBranchResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBranch> _RfBranch;
        private readonly IMapper _mapper;

        public RfBranchPostCommandHandler(IGenericRepositoryAsync<RfBranch> RfBranch, IMapper mapper)
        {
            _RfBranch = RfBranch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchResponseDto>> Handle(RfBranchPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfBranch = new RfBranch();

                RfBranch.Code = request.Code;
                RfBranch.Name = request.Name;
                RfBranch.Dati = request.Dati;
                RfBranch.GroupBranch = request.GroupBranch;
                RfBranch.Kanwil = request.Kanwil;
                RfBranch.KanwilName = request.KanwilName;
                RfBranch.KanwilOri = request.Kanwil;
                RfBranch.Kc = request.Kc;
                RfBranch.KcName = request.KcName;
                RfBranch.Kcp = request.Kcp;
                RfBranch.OfficeType = request.OfficeType;
                RfBranch.OriKanwilName = request.Kcp;
                RfBranch.Sandi = request.Sandi;

                var returnedRfStatusTarget = await _RfBranch.AddAsync(RfBranch, callSave: false);

                var response = _mapper.Map<RfBranchResponseDto>(returnedRfStatusTarget);

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
                await _RfBranch.SaveChangeAsync();
                return ServiceResponse<RfBranchResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBranchResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}