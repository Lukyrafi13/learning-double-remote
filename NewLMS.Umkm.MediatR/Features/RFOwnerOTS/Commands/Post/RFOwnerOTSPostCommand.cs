using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerOTSs.Commands
{
    public class RFOwnerOTSPostCommand : RFOwnerOTSPostRequestDto, IRequest<ServiceResponse<RFOwnerOTSResponseDto>>
    {

    }
    public class RFOwnerOTSPostCommandHandler : IRequestHandler<RFOwnerOTSPostCommand, ServiceResponse<RFOwnerOTSResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerOTS> _RFOwnerOTS;
        private readonly IMapper _mapper;

        public RFOwnerOTSPostCommandHandler(IGenericRepositoryAsync<RFOwnerOTS> RFOwnerOTS, IMapper mapper)
        {
            _RFOwnerOTS = RFOwnerOTS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFOwnerOTSResponseDto>> Handle(RFOwnerOTSPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFOwnerOTS = _mapper.Map<RFOwnerOTS>(request);

                var returnedRFOwnerOTS = await _RFOwnerOTS.AddAsync(RFOwnerOTS, callSave: false);

                // var response = _mapper.Map<RFOwnerOTSResponseDto>(returnedRFOwnerOTS);
                var response = _mapper.Map<RFOwnerOTSResponseDto>(returnedRFOwnerOTS);

                await _RFOwnerOTS.SaveChangeAsync();
                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}