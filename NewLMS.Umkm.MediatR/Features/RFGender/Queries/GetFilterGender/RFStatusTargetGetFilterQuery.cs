using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfGenders.Queries
{
    public class RfGendersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfGenderResponseDto>>>
    {
    }

    public class GetFilterRfGenderQueryHandler : IRequestHandler<RfGendersGetFilterQuery, PagedResponse<IEnumerable<RfGenderResponseDto>>>
    {
        private IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public GetFilterRfGenderQueryHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfGenderResponseDto>>> Handle(RfGendersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfGender.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfGenderResponseDto>>(data.Results);
            IEnumerable<RfGenderResponseDto> dataVm;
            var listResponse = new List<RfGenderResponseDto>();

            foreach (var gender in data.Results){
                var response = new RfGenderResponseDto();
                
                response.Id = gender.Id;
                response.GenderCode = gender.GenderCode;
                response.GenderDesc = gender.GenderDesc;
                response.CoreCode = gender.CoreCode;
                response.GenderCodeSIKP = gender.GenderCodeSIKP;
                response.GenderDescSIKP = gender.GenderDescSIKP;
                response.Active = gender.Active;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfGenderResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}