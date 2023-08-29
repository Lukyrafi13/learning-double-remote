using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.Umkm.Data.Dto.RFJOBs;

namespace NewLMS.Umkm.MediatR.Features.RFJOBs.Commands
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




