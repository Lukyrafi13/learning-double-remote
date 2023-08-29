using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKodeDinass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKodeDinass.Commands
{
    public class RFKodeDinasDeleteCommand : RFKodeDinasFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFKodeDinasCommandHandler : IRequestHandler<RFKodeDinasDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFKodeDinas> _RFKodeDinas;
        private readonly IMapper _mapper;

        public DeleteRFKodeDinasCommandHandler(IGenericRepositoryAsync<RFKodeDinas> RFKodeDinas, IMapper mapper){
            _RFKodeDinas = RFKodeDinas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFKodeDinasDeleteCommand request, CancellationToken cancellationToken)
        {
            var RFKodeDinas = await _RFKodeDinas.GetByIdAsync(request.KodeDinas, "KodeDinas");
            RFKodeDinas.IsDeleted = true;
            await _RFKodeDinas.UpdateAsync(RFKodeDinas);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}