using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikHistoryKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SlikHistoryKredits.Queries
{
    public class SlikHistoryKreditGetQuery : SlikHistoryKreditFindRequestDto, IRequest<ServiceResponse<SlikHistoryKreditResponseDto>>
    {
    }

    public class SlikHistoryKreditGetQueryHandler : IRequestHandler<SlikHistoryKreditGetQuery, ServiceResponse<SlikHistoryKreditResponseDto>>
    {
        private IGenericRepositoryAsync<SlikHistoryKredit> _SlikHistoryKredit;
        private readonly IMapper _mapper;

        public SlikHistoryKreditGetQueryHandler(IGenericRepositoryAsync<SlikHistoryKredit> SlikHistoryKredit, IMapper mapper)
        {
            _SlikHistoryKredit = SlikHistoryKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SlikHistoryKreditResponseDto>> Handle(SlikHistoryKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "RfCreditType",
                    "RfSandiBIEconomySectorClass",
                    "RfSandiBIBehaviourClass",
                    "RfSandiBIApplicationTypeClass",
                    "RfSandiBICollectibilityClass",
                    "RfCondition",
                    "SlikRequest",
                    "SlikObjectType",
                };

                var data = await _SlikHistoryKredit.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SlikHistoryKreditResponseDto>.Return404("Data SlikHistoryKredit not found");
                var response = _mapper.Map<SlikHistoryKreditResponseDto>(data);
                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}