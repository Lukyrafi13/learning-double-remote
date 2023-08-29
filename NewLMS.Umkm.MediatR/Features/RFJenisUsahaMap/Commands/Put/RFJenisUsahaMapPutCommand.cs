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
    public class RfCompanyTypeMapPutCommand : RfCompanyTypeMapPutRequestDto, IRequest<ServiceResponse<RfCompanyTypeMapResponseDto>>
    {
    }

    public class PutRfCompanyTypeMapCommandHandler : IRequestHandler<RfCompanyTypeMapPutCommand, ServiceResponse<RfCompanyTypeMapResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
        private readonly IMapper _mapper;

        public PutRfCompanyTypeMapCommandHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeMapResponseDto>> Handle(RfCompanyTypeMapPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCompanyTypeMap = await _RfCompanyTypeMap.GetByIdAsync(request.Id, "Id");
                existingRfCompanyTypeMap.ANL_CODE = request.ANL_CODE;
                existingRfCompanyTypeMap.KELOMPOK_CODE = request.KELOMPOK_CODE;
                existingRfCompanyTypeMap.PRODUCTID = request.PRODUCTID;

                await _RfCompanyTypeMap.UpdateAsync(existingRfCompanyTypeMap);

                var response = _mapper.Map<RfCompanyTypeMapResponseDto>(existingRfCompanyTypeMap);

                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}