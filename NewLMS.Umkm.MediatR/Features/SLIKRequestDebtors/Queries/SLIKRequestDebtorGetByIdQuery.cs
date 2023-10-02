using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Queries
{
    public class SLIKRequestDebtorGetByIdQuery : IRequest<ServiceResponse<SLIKRequestDebtorResponse>>
    {
        public Guid Id { get; set; }
    }
    public class SLIKRequestDebtorGetByIdQueryHandler : IRequestHandler<SLIKRequestDebtorGetByIdQuery, ServiceResponse<SLIKRequestDebtorResponse>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequest;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public SLIKRequestDebtorGetByIdQueryHandler(IGenericRepositoryAsync<SLIKRequestDebtor> slikRequest, IMapper mapper, IConfiguration config)
        {
            _slikRequest = slikRequest;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ServiceResponse<SLIKRequestDebtorResponse>> Handle(SLIKRequestDebtorGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "FileUrl",
                };
                var data = await _slikRequest.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SLIKRequestDebtorResponse>.Return404("Data SLIKRequest tidak ditemukan.");

                var dataVm = _mapper.Map<SLIKRequestDebtorResponse>(data);

                return ServiceResponse<SLIKRequestDebtorResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<SLIKRequestDebtorResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }

}
