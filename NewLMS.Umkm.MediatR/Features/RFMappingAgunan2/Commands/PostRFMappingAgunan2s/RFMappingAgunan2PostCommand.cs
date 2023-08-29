using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Commands
{
    public class RFMappingAgunan2PostCommand : RFMappingAgunan2PostRequestDto, IRequest<ServiceResponse<RFMappingAgunan2ResponseDto>>
    {

    }
    public class PostRFMappingAgunan2CommandHandler : IRequestHandler<RFMappingAgunan2PostCommand, ServiceResponse<RFMappingAgunan2ResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingAgunan2> _RFMappingAgunan2;
        private readonly IMapper _mapper;

        public PostRFMappingAgunan2CommandHandler(IGenericRepositoryAsync<RFMappingAgunan2> RFMappingAgunan2, IMapper mapper)
        {
            _RFMappingAgunan2 = RFMappingAgunan2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingAgunan2ResponseDto>> Handle(RFMappingAgunan2PostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFMappingAgunan2 = _mapper.Map<RFMappingAgunan2>(request);

                var returnedRFMappingAgunan2 = await _RFMappingAgunan2.AddAsync(RFMappingAgunan2, callSave: false);

                // var response = _mapper.Map<RFMappingAgunan2ResponseDto>(returnedRFMappingAgunan2);
                var response = _mapper.Map<RFMappingAgunan2ResponseDto>(returnedRFMappingAgunan2);

                await _RFMappingAgunan2.SaveChangeAsync();
                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}