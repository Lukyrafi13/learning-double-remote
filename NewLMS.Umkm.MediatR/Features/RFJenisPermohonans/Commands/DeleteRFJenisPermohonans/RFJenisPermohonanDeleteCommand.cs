using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Commands
{
    public class RfAppTypeDeleteCommand : RfAppTypeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfAppTypeCommandHandler : IRequestHandler<RfAppTypeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfAppType> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public DeleteRfAppTypeCommandHandler(IGenericRepositoryAsync<RfAppType> rfJenisPermohonan, IMapper mapper){
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfAppTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfJenisPermohonan = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");
            rfJenisPermohonan.IsDeleted = true;
            await _rfJenisPermohonan.UpdateAsync(rfJenisPermohonan);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}