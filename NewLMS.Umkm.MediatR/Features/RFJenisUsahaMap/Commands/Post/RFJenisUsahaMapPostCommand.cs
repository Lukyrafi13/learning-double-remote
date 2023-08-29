using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Commands
{
    public class RfCompanyTypeMapPostCommand : RfCompanyTypeMapPostRequestDto, IRequest<ServiceResponse<RfCompanyTypeMapResponseDto>>
    {

    }
    public class PostRfCompanyTypeMapCommandHandler : IRequestHandler<RfCompanyTypeMapPostCommand, ServiceResponse<RfCompanyTypeMapResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
        private readonly IMapper _mapper;

        public PostRfCompanyTypeMapCommandHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeMapResponseDto>> Handle(RfCompanyTypeMapPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCompanyTypeMap = _mapper.Map<RfCompanyTypeMap>(request);

                var returnedRfCompanyTypeMap = await _RfCompanyTypeMap.AddAsync(RfCompanyTypeMap, callSave: false);

                // var response = _mapper.Map<RfCompanyTypeMapResponseDto>(returnedRfCompanyTypeMap);
                var response = _mapper.Map<RfCompanyTypeMapResponseDto>(returnedRfCompanyTypeMap);

                await _RfCompanyTypeMap.SaveChangeAsync();
                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}