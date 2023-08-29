using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Commands
{
    public class RFSifatKreditPostCommand : RFSifatKreditPostRequestDto, IRequest<ServiceResponse<RFSifatKreditResponseDto>>
    {

    }
    public class PostRFSifatKreditCommandHandler : IRequestHandler<RFSifatKreditPostCommand, ServiceResponse<RFSifatKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSifatKredit> _RFSifatKredit;
        private readonly IMapper _mapper;

        public PostRFSifatKreditCommandHandler(IGenericRepositoryAsync<RFSifatKredit> RFSifatKredit, IMapper mapper)
        {
            _RFSifatKredit = RFSifatKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSifatKreditResponseDto>> Handle(RFSifatKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSifatKredit = _mapper.Map<RFSifatKredit>(request);

                var returnedRFSifatKredit = await _RFSifatKredit.AddAsync(RFSifatKredit, callSave: false);

                // var response = _mapper.Map<RFSifatKreditResponseDto>(returnedRFSifatKredit);
                var response = _mapper.Map<RFSifatKreditResponseDto>(returnedRFSifatKredit);

                await _RFSifatKredit.SaveChangeAsync();
                return ServiceResponse<RFSifatKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSifatKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}