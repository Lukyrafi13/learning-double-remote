using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveySuppliers.Commands
{
    public class SurveySupplierPostCommand : SurveySupplierPostRequestDto, IRequest<ServiceResponse<SurveySupplierResponseDto>>
    {

    }
    public class SurveySupplierPostCommandHandler : IRequestHandler<SurveySupplierPostCommand, ServiceResponse<SurveySupplierResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SurveySupplier> _SurveySupplier;
        private readonly IMapper _mapper;

        public SurveySupplierPostCommandHandler(IGenericRepositoryAsync<SurveySupplier> SurveySupplier, IMapper mapper)
        {
            _SurveySupplier = SurveySupplier;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveySupplierResponseDto>> Handle(SurveySupplierPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SurveySupplier = _mapper.Map<SurveySupplier>(request);

                var returnedSurveySupplier = await _SurveySupplier.AddAsync(SurveySupplier, callSave: false);

                // var response = _mapper.Map<SurveySupplierResponseDto>(returnedSurveySupplier);
                var response = _mapper.Map<SurveySupplierResponseDto>(returnedSurveySupplier);

                await _SurveySupplier.SaveChangeAsync();
                return ServiceResponse<SurveySupplierResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveySupplierResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}