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
    public class RfCompanyTypePostCommand : RfCompanyTypePostRequestDto, IRequest<ServiceResponse<RfCompanyTypeResponseDto>>
    {

    }
    public class PostRfCompanyTypeCommandHandler : IRequestHandler<RfCompanyTypePostCommand, ServiceResponse<RfCompanyTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public PostRfCompanyTypeCommandHandler(IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeResponseDto>> Handle(RfCompanyTypePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCompanyType = _mapper.Map<RfCompanyType>(request);

                var returnedRfCompanyType = await _RfCompanyType.AddAsync(RfCompanyType, callSave: false);

                // var response = _mapper.Map<RfCompanyTypeResponseDto>(returnedRfCompanyType);
                var response = _mapper.Map<RfCompanyTypeResponseDto>(returnedRfCompanyType);

                await _RfCompanyType.SaveChangeAsync();
                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}