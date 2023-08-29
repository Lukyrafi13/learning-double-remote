using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAsuransis.Commands
{
    public class RFJenisAsuransiPutCommand : RFJenisAsuransiPutRequestDto, IRequest<ServiceResponse<RFJenisAsuransiResponseDto>>
    {
    }

    public class RFJenisAsuransiPutCommandHandler : IRequestHandler<RFJenisAsuransiPutCommand, ServiceResponse<RFJenisAsuransiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAsuransi> _RFJenisAsuransi;
        private readonly IMapper _mapper;

        public RFJenisAsuransiPutCommandHandler(IGenericRepositoryAsync<RFJenisAsuransi> RFJenisAsuransi, IMapper mapper)
        {
            _RFJenisAsuransi = RFJenisAsuransi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisAsuransiResponseDto>> Handle(RFJenisAsuransiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisAsuransi = await _RFJenisAsuransi.GetByIdAsync(request.JenisCode, "JenisCode");
                
                existingRFJenisAsuransi = _mapper.Map<RFJenisAsuransiPutRequestDto, RFJenisAsuransi>(request, existingRFJenisAsuransi);
                
                await _RFJenisAsuransi.UpdateAsync(existingRFJenisAsuransi);

                var response = _mapper.Map<RFJenisAsuransiResponseDto>(existingRFJenisAsuransi);

                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}