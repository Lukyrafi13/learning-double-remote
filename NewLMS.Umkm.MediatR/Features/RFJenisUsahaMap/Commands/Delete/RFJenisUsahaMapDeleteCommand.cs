using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Commands
{
    public class RFJenisUsahaMapDeleteCommand : RFJenisUsahaMapFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJenisUsahaMapCommandHandler : IRequestHandler<RFJenisUsahaMapDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
        private readonly IMapper _mapper;

        public DeleteRFJenisUsahaMapCommandHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisUsahaMapDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisUsahaMap.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFJenisUsahaMap.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}