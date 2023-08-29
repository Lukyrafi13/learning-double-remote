using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Commands
{
    public class RFMappingLBU3PostCommand : RFMappingLBU3PostRequestDto, IRequest<ServiceResponse<RFMappingLBU3ResponseDto>>
    {

    }
    public class RFMappingLBU3PostCommandHandler : IRequestHandler<RFMappingLBU3PostCommand, ServiceResponse<RFMappingLBU3ResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public RFMappingLBU3PostCommandHandler(IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3, IMapper mapper)
        {
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingLBU3ResponseDto>> Handle(RFMappingLBU3PostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFMappingLBU3 = _mapper.Map<RFMappingLBU3>(request);

                var returnedRFMappingLBU3 = await _RFMappingLBU3.AddAsync(RFMappingLBU3, callSave: false);

                // var response = _mapper.Map<RFMappingLBU3ResponseDto>(returnedRFMappingLBU3);
                var response = _mapper.Map<RFMappingLBU3ResponseDto>(returnedRFMappingLBU3);

                await _RFMappingLBU3.SaveChangeAsync();
                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}