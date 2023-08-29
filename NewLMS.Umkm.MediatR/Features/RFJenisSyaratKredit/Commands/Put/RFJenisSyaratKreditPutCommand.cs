using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisSyaratKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisSyaratKredits.Commands
{
    public class RFJenisSyaratKreditPutCommand : RFJenisSyaratKreditPutRequestDto, IRequest<ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {
    }

    public class PutRFJenisSyaratKreditCommandHandler : IRequestHandler<RFJenisSyaratKreditPutCommand, ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisSyaratKredit> _RFJenisSyaratKredit;
        private readonly IMapper _mapper;

        public PutRFJenisSyaratKreditCommandHandler(IGenericRepositoryAsync<RFJenisSyaratKredit> RFJenisSyaratKredit, IMapper mapper)
        {
            _RFJenisSyaratKredit = RFJenisSyaratKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisSyaratKreditResponseDto>> Handle(RFJenisSyaratKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisSyaratKredit = await _RFJenisSyaratKredit.GetByIdAsync(request.SyaratCode, "SyaratCode");
                
                existingRFJenisSyaratKredit.SyaratDesc = request.SyaratDesc;
                existingRFJenisSyaratKredit.Active = request.Active;
                await _RFJenisSyaratKredit.UpdateAsync(existingRFJenisSyaratKredit);

                var response = _mapper.Map<RFJenisSyaratKreditResponseDto>(existingRFJenisSyaratKredit);

                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}