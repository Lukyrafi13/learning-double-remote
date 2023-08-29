using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Commands
{
    public class RFSiklusUsahaPutCommand : RFSiklusUsahaPutRequestDto, IRequest<ServiceResponse<RFSiklusUsahaResponseDto>>
    {
    }

    public class PutRFSiklusUsahaCommandHandler : IRequestHandler<RFSiklusUsahaPutCommand, ServiceResponse<RFSiklusUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsaha> _RFSiklusUsaha;
        private readonly IMapper _mapper;

        public PutRFSiklusUsahaCommandHandler(IGenericRepositoryAsync<RFSiklusUsaha> RFSiklusUsaha, IMapper mapper)
        {
            _RFSiklusUsaha = RFSiklusUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSiklusUsahaResponseDto>> Handle(RFSiklusUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSiklusUsaha = await _RFSiklusUsaha.GetByIdAsync(request.SiklusCode, "SiklusCode");
                
                existingRFSiklusUsaha.SiklusDesc = request.SiklusDesc;
                existingRFSiklusUsaha.CoreCode = request.CoreCode;
                existingRFSiklusUsaha.IsResiGudang = request.IsResiGudang;
                existingRFSiklusUsaha.MCount = request.MCount;
                existingRFSiklusUsaha.Active = request.Active;

                await _RFSiklusUsaha.UpdateAsync(existingRFSiklusUsaha);

                var response = _mapper.Map<RFSiklusUsahaResponseDto>(existingRFSiklusUsaha);

                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}