﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfZipcodes.Queries
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
