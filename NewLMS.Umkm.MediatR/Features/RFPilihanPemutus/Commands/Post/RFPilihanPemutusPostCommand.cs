using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPilihanPemutuss;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPilihanPemutuss.Commands
{
    public class RFPilihanPemutusPostCommand : RFPilihanPemutusPostRequestDto, IRequest<ServiceResponse<RFPilihanPemutusResponseDto>>
    {

    }
    public class RFPilihanPemutusPostCommandHandler : IRequestHandler<RFPilihanPemutusPostCommand, ServiceResponse<RFPilihanPemutusResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPilihanPemutus> _RFPilihanPemutus;
        private readonly IMapper _mapper;

        public RFPilihanPemutusPostCommandHandler(IGenericRepositoryAsync<RFPilihanPemutus> RFPilihanPemutus, IMapper mapper)
        {
            _RFPilihanPemutus = RFPilihanPemutus;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPilihanPemutusResponseDto>> Handle(RFPilihanPemutusPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFPilihanPemutus = _mapper.Map<RFPilihanPemutus>(request);

                var returnedRFPilihanPemutus = await _RFPilihanPemutus.AddAsync(RFPilihanPemutus, callSave: false);

                // var response = _mapper.Map<RFPilihanPemutusResponseDto>(returnedRFPilihanPemutus);
                var response = _mapper.Map<RFPilihanPemutusResponseDto>(returnedRFPilihanPemutus);

                await _RFPilihanPemutus.SaveChangeAsync();
                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}