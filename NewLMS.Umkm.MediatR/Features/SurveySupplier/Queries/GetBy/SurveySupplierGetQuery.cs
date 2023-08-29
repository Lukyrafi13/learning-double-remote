using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SurveySuppliers.Queries
{
    public class SurveySupplierGetQuery : SurveySupplierFindRequestDto, IRequest<ServiceResponse<SurveySupplierResponseDto>>
    {
    }

    public class SurveySupplierGetQueryHandler : IRequestHandler<SurveySupplierGetQuery, ServiceResponse<SurveySupplierResponseDto>>
    {
        private IGenericRepositoryAsync<SurveySupplier> _SurveySupplier;
        private readonly IMapper _mapper;

        public SurveySupplierGetQueryHandler(IGenericRepositoryAsync<SurveySupplier> SurveySupplier, IMapper mapper)
        {
            _SurveySupplier = SurveySupplier;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SurveySupplierResponseDto>> Handle(SurveySupplierGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Survey",
                    "MetodePembayaran"
                };

                var data = await _SurveySupplier.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SurveySupplierResponseDto>.Return404("Data SurveySupplier not found");
                var response = _mapper.Map<SurveySupplierResponseDto>(data);
                return ServiceResponse<SurveySupplierResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveySupplierResponseDto>.ReturnException(ex);
            }
        }
    }
}