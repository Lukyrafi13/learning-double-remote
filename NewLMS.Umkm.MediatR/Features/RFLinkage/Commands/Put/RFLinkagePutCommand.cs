using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLinkages;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLinkages.Commands
{
    public class RFLinkagePutCommand : RFLinkagePutRequestDto, IRequest<ServiceResponse<RFLinkageResponseDto>>
    {
    }

    public class PutRFLinkageCommandHandler : IRequestHandler<RFLinkagePutCommand, ServiceResponse<RFLinkageResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private readonly IMapper _mapper;

        public PutRFLinkageCommandHandler(IGenericRepositoryAsync<RFLinkage> RFLinkage, IMapper mapper)
        {
            _RFLinkage = RFLinkage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLinkageResponseDto>> Handle(RFLinkagePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFLinkage = await _RFLinkage.GetByIdAsync(request.LinkCode, "LinkCode");
                
                existingRFLinkage.LinkDesc = request.LinkDesc;
                existingRFLinkage.SIKPCode = request.SIKPCode;
                existingRFLinkage.Active = request.Active;
                await _RFLinkage.UpdateAsync(existingRFLinkage);

                var response = _mapper.Map<RFLinkageResponseDto>(existingRFLinkage);

                return ServiceResponse<RFLinkageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLinkageResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}