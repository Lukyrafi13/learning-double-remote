using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Commands
{
    public class RFSiklusUsahaPokokPutCommand : RFSiklusUsahaPokokPutRequestDto, IRequest<ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {
    }

    public class PutRFSiklusUsahaPokokCommandHandler : IRequestHandler<RFSiklusUsahaPokokPutCommand, ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public PutRFSiklusUsahaPokokCommandHandler(IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSiklusUsahaPokokResponseDto>> Handle(RFSiklusUsahaPokokPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSiklusUsahaPokok = await _RFSiklusUsahaPokok.GetByIdAsync(request.SiklusCode, "SiklusCode");
                
                existingRFSiklusUsahaPokok.SiklusDesc = request.SiklusDesc;
                existingRFSiklusUsahaPokok.CoreCode = request.CoreCode;
                existingRFSiklusUsahaPokok.Active = request.Active;

                await _RFSiklusUsahaPokok.UpdateAsync(existingRFSiklusUsahaPokok);

                var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(existingRFSiklusUsahaPokok);

                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}