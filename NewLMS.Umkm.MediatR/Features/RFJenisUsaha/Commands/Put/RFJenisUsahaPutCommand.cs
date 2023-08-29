using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Commands
{
    public class RfCompanyTypePutCommand : RfCompanyTypePutRequestDto, IRequest<ServiceResponse<RfCompanyTypeResponseDto>>
    {
    }

    public class PutRfCompanyTypeCommandHandler : IRequestHandler<RfCompanyTypePutCommand, ServiceResponse<RfCompanyTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public PutRfCompanyTypeCommandHandler(IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeResponseDto>> Handle(RfCompanyTypePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCompanyType = await _RfCompanyType.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRfCompanyType.ANL_CODE = request.ANL_CODE;
                existingRfCompanyType.ANL_DESC = request.ANL_DESC;
                existingRfCompanyType.CORE_CODE = request.CORE_CODE;
                existingRfCompanyType.ACTIVE = request.ACTIVE;

                await _RfCompanyType.UpdateAsync(existingRfCompanyType);

                var response = _mapper.Map<RfCompanyTypeResponseDto>(existingRfCompanyType);

                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}