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
    public class RfBranchPutCommand : RfBranchPutRequestDto, IRequest<ServiceResponse<RfBranchResponseDto>>
    {
    }

    public class RfBranchPutCommandHandler : IRequestHandler<RfBranchPutCommand, ServiceResponse<RfBranchResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBranch> _RfBranch;
        private readonly IMapper _mapper;

        public RfBranchPutCommandHandler(IGenericRepositoryAsync<RfBranch> RfBranch, IMapper mapper){
            _RfBranch = RfBranch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBranchResponseDto>> Handle(RfBranchPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfBranch = await _RfBranch.GetByIdAsync(request.Code, "Code");
                existingRfBranch.Code = request.Code;
                existingRfBranch.Name = request.Name;
                existingRfBranch.Dati = request.Dati;
                existingRfBranch.GroupBranch = request.GroupBranch;
                existingRfBranch.Kanwil = request.Kanwil;
                existingRfBranch.KanwilName = request.KanwilName;
                existingRfBranch.KanwilOri = request.KanwilOri;
                existingRfBranch.Kc = request.Kc;
                existingRfBranch.KcName = request.KcName;
                existingRfBranch.Kcp = request.Kcp;
                existingRfBranch.OfficeType = request.OfficeType;
                existingRfBranch.OriKanwilName = request.OriKanwilName;
                existingRfBranch.Sandi = request.Sandi;
                
                await _RfBranch.UpdateAsync(existingRfBranch);

                var response = _mapper.Map<RfBranchResponseDto>(existingRfBranch);

                return ServiceResponse<RfBranchResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBranchResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}