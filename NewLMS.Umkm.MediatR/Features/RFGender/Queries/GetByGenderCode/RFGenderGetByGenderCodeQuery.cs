using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFGenders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFGenders.Queries
{
    public class RFGendersGetByGenderCodeQuery : RFGenderFindRequestDto, IRequest<ServiceResponse<RFGenderResponseDto>>
    {
    }

    public class GetByIdRFGenderQueryHandler : IRequestHandler<RFGendersGetByGenderCodeQuery, ServiceResponse<RFGenderResponseDto>>
    {
        private IGenericRepositoryAsync<RFGender> _rfGender;
        private readonly IMapper _mapper;

        public GetByIdRFGenderQueryHandler(IGenericRepositoryAsync<RFGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFGenderResponseDto>> Handle(RFGendersGetByGenderCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");

            var response = new RFGenderResponseDto();
            response.Id = data.Id;
            response.GenderCode = data.GenderCode;
            response.GenderDesc = data.GenderDesc;
            response.CoreCode = data.CoreCode;
            response.GenderCodeSIKP = data.GenderCodeSIKP;
            response.GenderDescSIKP = data.GenderDescSIKP;
            response.Active = data.Active;
            
            return ServiceResponse<RFGenderResponseDto>.ReturnResultWith200(response);
        }
    }
}