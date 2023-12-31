﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Exceptions;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationKeyPersons.Queries
{
    public class LoanApplicationKeyPersonGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationKeyPersonResponse>>>
    {
    }

    public class LoanApplicationKeyPersonGetFilterQueryHandler : IRequestHandler<LoanApplicationKeyPersonGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationKeyPersonResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationKeyPerson> _core;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonGetFilterQueryHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationKeyPersonResponse>>> Handle(LoanApplicationKeyPersonGetFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                "RfEducation",
                "RfMarital",
                "RfZipCode",
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationKeyPersonResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationKeyPersonResponse>>(dataVm, data.Info, request.Page, request.Length)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
