using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Queries
{
    public class RFJenisSyaratKreditGetQuery : RFJenisSyaratKreditFindRequestDto, IRequest<ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {
    }

    public class RFJenisSyaratKreditGetQueryHandler : IRequestHandler<RFJenisSyaratKreditGetQuery, ServiceResponse<RFJenisSyaratKreditResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisSyaratKredit> _RFJenisSyaratKredit;
        private readonly IMapper _mapper;

        public RFJenisSyaratKreditGetQueryHandler(IGenericRepositoryAsync<RFJenisSyaratKredit> RFJenisSyaratKredit, IMapper mapper)
        {
            _RFJenisSyaratKredit = RFJenisSyaratKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisSyaratKreditResponseDto>> Handle(RFJenisSyaratKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFJenisSyaratKredit.GetByIdAsync(request.SyaratCode, "SyaratCode");
                if (data == null)
                    return ServiceResponse<RFJenisSyaratKreditResponseDto>.Return404("Data RFJenisSyaratKredit not found");
                var response = _mapper.Map<RFJenisSyaratKreditResponseDto>(data);
                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisSyaratKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}