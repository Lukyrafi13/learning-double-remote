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
    public class RFJenisAsuransiPostCommand : RFJenisAsuransiPostRequestDto, IRequest<ServiceResponse<RFJenisAsuransiResponseDto>>
    {

    }
    public class RFJenisAsuransiPostCommandHandler : IRequestHandler<RFJenisAsuransiPostCommand, ServiceResponse<RFJenisAsuransiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAsuransi> _RFJenisAsuransi;
        private readonly IMapper _mapper;

        public RFJenisAsuransiPostCommandHandler(IGenericRepositoryAsync<RFJenisAsuransi> RFJenisAsuransi, IMapper mapper)
        {
            _RFJenisAsuransi = RFJenisAsuransi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisAsuransiResponseDto>> Handle(RFJenisAsuransiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisAsuransi = _mapper.Map<RFJenisAsuransi>(request);

                var returnedRFJenisAsuransi = await _RFJenisAsuransi.AddAsync(RFJenisAsuransi, callSave: false);

                // var response = _mapper.Map<RFJenisAsuransiResponseDto>(returnedRFJenisAsuransi);
                var response = _mapper.Map<RFJenisAsuransiResponseDto>(returnedRFJenisAsuransi);

                await _RFJenisAsuransi.SaveChangeAsync();
                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}