using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Queries
{
    public class RFZipCodesGetByIdQuery : IRequest<ServiceResponse<RFZipCodeResponse>>
    {
        public string ZipCode { get; set; }
    }

    public class GetByIdRFZipCodeQueryHandler : IRequestHandler<RFZipCodesGetByIdQuery, ServiceResponse<RFZipCodeResponse>>
    {
        private IGenericRepositoryAsync<RFZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public GetByIdRFZipCodeQueryHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFZipCodeResponse>> Handle(RFZipCodesGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfZipCode.GetByIdAsync(request.ZipCode, "ZipCode");
                if (data == null)
                    return ServiceResponse<RFZipCodeResponse>.Return404("Data RFZipCode not found");
                var dataVm = _mapper.Map<RFZipCodeResponse>(data);
                return ServiceResponse<RFZipCodeResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RFZipCodeResponse>.ReturnException(ex);
            }

        }
    }
}
