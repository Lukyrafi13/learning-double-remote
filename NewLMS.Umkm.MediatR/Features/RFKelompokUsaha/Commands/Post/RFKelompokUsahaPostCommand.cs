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
    public class RfCompanyGroupPostCommand : RfCompanyGroupPostRequestDto, IRequest<ServiceResponse<RfCompanyGroupResponseDto>>
    {

    }
    public class PostRfCompanyGroupCommandHandler : IRequestHandler<RfCompanyGroupPostCommand, ServiceResponse<RfCompanyGroupResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyGroup> _RfCompanyGroup;
        private readonly IMapper _mapper;

        public PostRfCompanyGroupCommandHandler(IGenericRepositoryAsync<RfCompanyGroup> RfCompanyGroup, IMapper mapper)
        {
            _RfCompanyGroup = RfCompanyGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyGroupResponseDto>> Handle(RfCompanyGroupPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCompanyGroup = _mapper.Map<RfCompanyGroup>(request);

                var returnedRfCompanyGroup = await _RfCompanyGroup.AddAsync(RfCompanyGroup, callSave: false);

                // var response = _mapper.Map<RfCompanyGroupResponseDto>(returnedRfCompanyGroup);
                var response = _mapper.Map<RfCompanyGroupResponseDto>(returnedRfCompanyGroup);

                await _RfCompanyGroup.SaveChangeAsync();
                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}