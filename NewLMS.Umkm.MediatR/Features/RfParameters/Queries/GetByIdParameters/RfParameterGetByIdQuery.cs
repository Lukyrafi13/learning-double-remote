using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Queries.GetByIdParameters
{
    public class RfParametersGetByIdQuery : IRequest<ServiceResponse<RfParameterResponse>>
    {
        public int ParameterId { get; set; }
    }

    public class GetByIdRfParameterQueryHandler : IRequestHandler<RfParametersGetByIdQuery, ServiceResponse<RfParameterResponse>>
    {
        private IGenericRepositoryAsync<RfParameter> _rfParameter;
        private readonly IMapper _mapper;

        public GetByIdRfParameterQueryHandler(IGenericRepositoryAsync<RfParameter> rfParameter, IMapper mapper)
        {
            _rfParameter = rfParameter;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfParameterResponse>> Handle(RfParametersGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "RfParameterDetails" };
                var data = await _rfParameter.GetByIdAsync(request.ParameterId, "ParameterId", includes);
                if (data == null)
                    return ServiceResponse<RfParameterResponse>.Return404("Data RfParameter not found");
                var dataVm = _mapper.Map<RfParameterResponse>(data);
                return ServiceResponse<RfParameterResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfParameterResponse>.ReturnException(ex);
            }

        }
    }
}
