using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.UMKM.Data.Dto.RFJOBs;

namespace NewLMS.UMKM.MediatR.Features.RFJOBs.Commands
{
    public class RFJOBDeleteCommand : RFJOBFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJOBCommandHandler : IRequestHandler<RFJOBDeleteCommand, ServiceResponse<Unit>>

    {
        private readonly IGenericRepositoryAsync<RFJOB> _RFJOB;
        private readonly IMapper _mapper;

        public DeleteRFJOBCommandHandler(IGenericRepositoryAsync<RFJOB> RFJOB, IMapper mapper)
        {
            _RFJOB = RFJOB;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJOBDeleteCommand request, CancellationToken cancellationToken)
        {
            var RFJOB = await _RFJOB.GetByIdAsync(request.JOB_CODE, "JOB_CODE");
            RFJOB.IsDeleted = true;
            await _RFJOB.UpdateAsync(RFJOB);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }

    }
}




