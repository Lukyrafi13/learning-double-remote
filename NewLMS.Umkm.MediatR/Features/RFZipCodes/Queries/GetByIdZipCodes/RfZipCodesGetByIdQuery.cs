using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Queries
{
    public class RfZipCodesGetByIdQuery : IRequest<ServiceResponse<RfZipCodeResponse>>
    {
        public string ZipCode { get; set; }
    }

    public class GetByIdRfZipCodeQueryHandler : IRequestHandler<RfZipCodesGetByIdQuery, ServiceResponse<RfZipCodeResponse>>
    {
        private IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public GetByIdRfZipCodeQueryHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfZipCodeResponse>> Handle(RfZipCodesGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfZipCode.GetByIdAsync(request.ZipCode, "ZipCode");
                if (data == null)
                    return ServiceResponse<RfZipCodeResponse>.Return404("Data RfZipCode not found");
                var dataVm = _mapper.Map<RfZipCodeResponse>(data);
                return ServiceResponse<RfZipCodeResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfZipCodeResponse>.ReturnException(ex);
            }

        }
    }
}
