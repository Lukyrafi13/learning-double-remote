using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfGenders.Queries
{
    public class RfGendersGetByGenderCodeQuery : RfGenderFindRequestDto, IRequest<ServiceResponse<RfGenderResponseDto>>
    {
    }

    public class GetByIdRfGenderQueryHandler : IRequestHandler<RfGendersGetByGenderCodeQuery, ServiceResponse<RfGenderResponseDto>>
    {
        private IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public GetByIdRfGenderQueryHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfGenderResponseDto>> Handle(RfGendersGetByGenderCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");

            var response = new RfGenderResponseDto();
            response.Id = data.Id;
            response.GenderCode = data.GenderCode;
            response.GenderDesc = data.GenderDesc;
            response.CoreCode = data.CoreCode;
            response.GenderCodeSIKP = data.GenderCodeSIKP;
            response.GenderDescSIKP = data.GenderDescSIKP;
            response.Active = data.Active;
            
            return ServiceResponse<RfGenderResponseDto>.ReturnResultWith200(response);
        }
    }
}