using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SurveySuppliers;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SurveySuppliers.Queries
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