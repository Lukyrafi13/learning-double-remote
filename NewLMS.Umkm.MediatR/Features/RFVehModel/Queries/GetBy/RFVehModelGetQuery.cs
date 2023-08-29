using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVehModels;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFVehModels.Queries
{
    public class RFVehModelGetQuery : RFVehModelFindRequestDto, IRequest<ServiceResponse<RFVehModelResponseDto>>
    {
    }

    public class RFVehModelGetQueryHandler : IRequestHandler<RFVehModelGetQuery, ServiceResponse<RFVehModelResponseDto>>
    {
        private IGenericRepositoryAsync<RFVehModel> _RFVehModel;
        private readonly IMapper _mapper;

        public RFVehModelGetQueryHandler(IGenericRepositoryAsync<RFVehModel> RFVehModel, IMapper mapper)
        {
            _RFVehModel = RFVehModel;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFVehModelResponseDto>> Handle(RFVehModelGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFVehModel.GetByIdAsync(request.VMDL_CODE, "VMDL_CODE");
                if (data == null)
                    return ServiceResponse<RFVehModelResponseDto>.Return404("Data RFVehModel not found");
                var response = _mapper.Map<RFVehModelResponseDto>(data);
                return ServiceResponse<RFVehModelResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehModelResponseDto>.ReturnException(ex);
            }
        }
    }
}