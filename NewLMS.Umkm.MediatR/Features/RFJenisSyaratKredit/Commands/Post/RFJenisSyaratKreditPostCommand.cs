using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Commands
{
    public class RFJenisSyaratKreditPostCommand : RFJenisSyaratKreditPostRequestDto, IRequest<ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {

    }
    public class RFJenisSyaratKreditPostCommandHandler : IRequestHandler<RFJenisSyaratKreditPostCommand, ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisSyaratKredit> _RFJenisSyaratKredit;
        private readonly IMapper _mapper;

        public RFJenisSyaratKreditPostCommandHandler(IGenericRepositoryAsync<RFJenisSyaratKredit> RFJenisSyaratKredit, IMapper mapper)
        {
            _RFJenisSyaratKredit = RFJenisSyaratKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisSyaratKreditResponseDto>> Handle(RFJenisSyaratKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisSyaratKredit = _mapper.Map<RFJenisSyaratKredit>(request);

                var returnedRFJenisSyaratKredit = await _RFJenisSyaratKredit.AddAsync(RFJenisSyaratKredit, callSave: false);

                // var response = _mapper.Map<RFJenisSyaratKreditResponseDto>(returnedRFJenisSyaratKredit);
                var response = _mapper.Map<RFJenisSyaratKreditResponseDto>(returnedRFJenisSyaratKredit);

                await _RFJenisSyaratKredit.SaveChangeAsync();
                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}