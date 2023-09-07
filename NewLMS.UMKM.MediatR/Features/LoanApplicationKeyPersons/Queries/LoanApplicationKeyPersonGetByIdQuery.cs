using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Queries
{
    public class LoanApplicationKeyPersonGetByIdQuery : IRequest<ServiceResponse<LoanApplicationKeyPersonResponse>>
    {
        public Guid Id { get; set; }
    }

    public class LoanApplicationKeyPersonGetByIdQueryHandler : IRequestHandler<LoanApplicationKeyPersonGetByIdQuery, ServiceResponse<LoanApplicationKeyPersonResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationKeyPerson> _core;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonGetByIdQueryHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationKeyPersonResponse>> Handle(LoanApplicationKeyPersonGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "RfEducation",
                    "RfMarital",
                    "RfZipCode",
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id,includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationKeyPersonResponse>.Return404("Data Key Person tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationKeyPersonResponse>(data);
                return ServiceResponse<LoanApplicationKeyPersonResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationKeyPersonResponse>.ReturnException(ex);
            }

        }
    }
}
