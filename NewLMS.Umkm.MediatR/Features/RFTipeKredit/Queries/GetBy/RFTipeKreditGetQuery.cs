using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Queries
{
    public class RfCreditTypeGetQuery : RfCreditTypeFindRequestDto, IRequest<ServiceResponse<RfCreditTypeResponseDto>>
    {
    }

    public class RfCreditTypeGetQueryHandler : IRequestHandler<RfCreditTypeGetQuery, ServiceResponse<RfCreditTypeResponseDto>>
    {
        private IGenericRepositoryAsync<RfCreditType> _RfCreditType;
        private readonly IMapper _mapper;

        public RfCreditTypeGetQueryHandler(IGenericRepositoryAsync<RfCreditType> RfCreditType, IMapper mapper)
        {
            _RfCreditType = RfCreditType;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCreditTypeResponseDto>> Handle(RfCreditTypeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RfCreditType.GetByIdAsync(request.Code, "Code");
                if (data == null)
                    return ServiceResponse<RfCreditTypeResponseDto>.Return404("Data RfCreditType not found");
                var response = _mapper.Map<RfCreditTypeResponseDto>(data);
                return ServiceResponse<RfCreditTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCreditTypeResponseDto>.ReturnException(ex);
            }
        }
    }
}