using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveyBuyers.Commands
{
    public class SurveyBuyerPostCommand : SurveyBuyerPostRequestDto, IRequest<ServiceResponse<SurveyBuyerResponseDto>>
    {

    }
    public class SurveyBuyerPostCommandHandler : IRequestHandler<SurveyBuyerPostCommand, ServiceResponse<SurveyBuyerResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SurveyBuyer> _SurveyBuyer;
        private readonly IMapper _mapper;

        public SurveyBuyerPostCommandHandler(IGenericRepositoryAsync<SurveyBuyer> SurveyBuyer, IMapper mapper)
        {
            _SurveyBuyer = SurveyBuyer;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveyBuyerResponseDto>> Handle(SurveyBuyerPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SurveyBuyer = _mapper.Map<SurveyBuyer>(request);

                var returnedSurveyBuyer = await _SurveyBuyer.AddAsync(SurveyBuyer, callSave: false);

                // var response = _mapper.Map<SurveyBuyerResponseDto>(returnedSurveyBuyer);
                var response = _mapper.Map<SurveyBuyerResponseDto>(returnedSurveyBuyer);

                await _SurveyBuyer.SaveChangeAsync();
                return ServiceResponse<SurveyBuyerResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveyBuyerResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}