using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Commands
{
    public class RfCompanyGroupPutCommand : RfCompanyGroupPutRequestDto, IRequest<ServiceResponse<RfCompanyGroupResponseDto>>
    {
    }

    public class PutRfCompanyGroupCommandHandler : IRequestHandler<RfCompanyGroupPutCommand, ServiceResponse<RfCompanyGroupResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyGroup> _RfCompanyGroup;
        private readonly IMapper _mapper;

        public PutRfCompanyGroupCommandHandler(IGenericRepositoryAsync<RfCompanyGroup> RfCompanyGroup, IMapper mapper){
            _RfCompanyGroup = RfCompanyGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyGroupResponseDto>> Handle(RfCompanyGroupPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCompanyGroup = await _RfCompanyGroup.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRfCompanyGroup.ANL_CODE = request.ANL_CODE;
                existingRfCompanyGroup.ANL_DESC = request.ANL_DESC;
                existingRfCompanyGroup.CORE_CODE = request.CORE_CODE;
                existingRfCompanyGroup.ACTIVE = request.ACTIVE;
                
                await _RfCompanyGroup.UpdateAsync(existingRfCompanyGroup);

                var response = _mapper.Map<RfCompanyGroupResponseDto>(existingRfCompanyGroup);

                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}