using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands
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
            var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id");
            prospect.IsDeleted = true;
            await _prospect.UpdateAsync(prospect);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}