using AutoMapper;
using MediatR;
using NewLMS.Umkm.Helper;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.Umkm.SIKP.Interfaces;

namespace NewLMS.Umkm.MediatR.Features.SIKP.Queries.Commands
{
    public class SIKPPostCalonDebiturCommand : PostCalonDebiturRequestModel, IRequest<ServiceResponse<PostCalonDebiturResponseModel>>
    {

    }

    public class SIKPPostCalonDebiturCommandHandler : IRequestHandler<SIKPPostCalonDebiturCommand, ServiceResponse<PostCalonDebiturResponseModel>>
    {
        private ISIKPService _SIKPService;
        private readonly IMapper _mapper;

        public SIKPPostCalonDebiturCommandHandler(
            ISIKPService SIKPService,
            IMapper mapper)
        {
            _SIKPService = SIKPService;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<PostCalonDebiturResponseModel>> Handle(SIKPPostCalonDebiturCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _SIKPService.PostCalonDebitur(request);
                if (data == null)
                    return ServiceResponse<PostCalonDebiturResponseModel>.Return404("Data SIKPService not found");

                // var response = _mapper.Map<CalonDebiturResponseModel>(data);
                return ServiceResponse<PostCalonDebiturResponseModel>.ReturnResultWith200(data);
            }
            catch (Exception ex)
            {
                return ServiceResponse<PostCalonDebiturResponseModel>.ReturnException(ex);
            }
        }
    }
}