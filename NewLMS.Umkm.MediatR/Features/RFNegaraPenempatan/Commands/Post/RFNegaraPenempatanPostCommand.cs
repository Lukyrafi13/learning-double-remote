using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanPostCommand : RFPlacementCountryPostRequestDto, IRequest<ServiceResponse<RFPlacementCountryResponseDto>>
    {

    }
    public class PostRFNegaraPenempatanCommandHandler : IRequestHandler<RFNegaraPenempatanPostCommand, ServiceResponse<RFPlacementCountryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPlacementCountry> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public PostRFNegaraPenempatanCommandHandler(IGenericRepositoryAsync<RFPlacementCountry> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPlacementCountryResponseDto>> Handle(RFNegaraPenempatanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFNegaraPenempatan = _mapper.Map<RFPlacementCountry>(request);

                var returnedRFNegaraPenempatan = await _RFNegaraPenempatan.AddAsync(RFNegaraPenempatan, callSave: false);

                // var response = _mapper.Map<RFNegaraPenempatanResponseDto>(returnedRFNegaraPenempatan);
                var response = _mapper.Map<RFPlacementCountryResponseDto>(returnedRFNegaraPenempatan);

                await _RFNegaraPenempatan.SaveChangeAsync();
                return ServiceResponse<RFPlacementCountryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPlacementCountryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}