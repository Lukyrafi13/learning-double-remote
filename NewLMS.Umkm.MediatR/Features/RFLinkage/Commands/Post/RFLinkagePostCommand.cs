using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLinkages;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLinkages.Commands
{
    public class RFLinkagePostCommand : RFLinkagePostRequestDto, IRequest<ServiceResponse<RFLinkageResponseDto>>
    {

    }
    public class RFLinkagePostCommandHandler : IRequestHandler<RFLinkagePostCommand, ServiceResponse<RFLinkageResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private readonly IMapper _mapper;

        public RFLinkagePostCommandHandler(IGenericRepositoryAsync<RFLinkage> RFLinkage, IMapper mapper)
        {
            _RFLinkage = RFLinkage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLinkageResponseDto>> Handle(RFLinkagePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFLinkage = _mapper.Map<RFLinkage>(request);

                var returnedRFLinkage = await _RFLinkage.AddAsync(RFLinkage, callSave: false);

                // var response = _mapper.Map<RFLinkageResponseDto>(returnedRFLinkage);
                var response = _mapper.Map<RFLinkageResponseDto>(returnedRFLinkage);

                await _RFLinkage.SaveChangeAsync();
                return ServiceResponse<RFLinkageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLinkageResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}