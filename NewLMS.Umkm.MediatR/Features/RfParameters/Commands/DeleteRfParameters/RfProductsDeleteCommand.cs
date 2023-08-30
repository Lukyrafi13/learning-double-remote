using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameters;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Helper;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.DeleteRfParameters
{
    public class RfParameterDeleteCommand : RfParameterDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfParameterCommandHandler : IRequestHandler<RfParameterDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameter> _rfParameter;
        private readonly IMapper _mapper;

        public DeleteRfParameterCommandHandler(IGenericRepositoryAsync<RfParameter> product, IMapper mapper)
        {
            _rfParameter = product;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfParameter = await _rfParameter.GetByIdAsync(request.ParameterId, "ParameterId");

            rfParameter.DeletedDate = DateTime.Now;
            rfParameter.IsDeleted = true;

            await _rfParameter.UpdateAsync(rfParameter);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
