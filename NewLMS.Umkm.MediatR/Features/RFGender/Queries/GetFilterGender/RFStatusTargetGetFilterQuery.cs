using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFGenders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFGenders.Queries
{
    public class RFGendersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFGenderResponseDto>>>
    {
    }

    public class GetFilterRFGenderQueryHandler : IRequestHandler<RFGendersGetFilterQuery, PagedResponse<IEnumerable<RFGenderResponseDto>>>
    {
        private IGenericRepositoryAsync<RFGender> _rfGender;
        private readonly IMapper _mapper;

        public GetFilterRFGenderQueryHandler(IGenericRepositoryAsync<RFGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFGenderResponseDto>>> Handle(RFGendersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfGender.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFGenderResponseDto>>(data.Results);
            IEnumerable<RFGenderResponseDto> dataVm;
            var listResponse = new List<RFGenderResponseDto>();

            foreach (var gender in data.Results){
                var response = new RFGenderResponseDto();
                
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
            return new PagedResponse<IEnumerable<RFGenderResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}