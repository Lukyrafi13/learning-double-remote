using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands
{
    public class ProspectDeleteCommand : ProspectFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteProspectCommandHandler : IRequestHandler<ProspectDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public DeleteProspectCommandHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper){
            _prospect = prospect;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ProspectDeleteCommand request, CancellationToken cancellationToken)
        {
            var prospect = await _prospect.GetByIdAsync(request.Id, "Id");
            prospect.IsDeleted = true;
            await _prospect.UpdateAsync(prospect);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}