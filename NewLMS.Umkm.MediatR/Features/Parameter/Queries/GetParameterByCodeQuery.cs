using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;

namespace NewLMS.Umkm.MediatR.Features.Parameter.Queries
{
    public class GetParameterByCodeQuery : IRequest<ServiceResponse<List<SimpleResponse<Guid>>>>
    {
        public string ParameterGroupCode;
    }

    public class GetParameterByCodeQueryHandler : IRequestHandler<GetParameterByCodeQuery, ServiceResponse<List<SimpleResponse<Guid>>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<Parameters> _parameter;

        public GetParameterByCodeQueryHandler(IMapper mapper, IGenericRepositoryAsync<Parameters> parameter)
        {
            _mapper = mapper;
            _parameter = parameter;
        }
        public async Task<ServiceResponse<List<SimpleResponse<Guid>>>> Handle(GetParameterByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dataVm = new List<SimpleResponse<Guid>>();
                if (request.ParameterGroupCode == null)
                {
                    var parameters = await _parameter.GetAllAsync();
                    dataVm = _mapper.Map<List<SimpleResponse<Guid>>>(parameters);
                }
                else
                {
                    var include = new string[] {
                        "ParameterGroups"
                    };
                    var parameters = await _parameter.GetListByPredicate(x => x.ParameterGroups.ParamaterGroupCode == request.ParameterGroupCode, include);
                    dataVm = _mapper.Map<List<SimpleResponse<Guid>>>(parameters);
                }
                return ServiceResponse<List<SimpleResponse<Guid>>>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponse<Guid>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}