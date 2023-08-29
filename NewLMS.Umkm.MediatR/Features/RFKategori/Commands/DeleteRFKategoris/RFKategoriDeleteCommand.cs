using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKategoris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKategoris.Commands
{
    public class RFKategoriDeleteCommand : RFKategoriFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFKategoriCommandHandler : IRequestHandler<RFKategoriDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFKategori> _RFKategori;
        private readonly IMapper _mapper;

        public DeleteRFKategoriCommandHandler(IGenericRepositoryAsync<RFKategori> RFKategori, IMapper mapper){
            _RFKategori = RFKategori;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFKategoriDeleteCommand request, CancellationToken cancellationToken)
        {
            var RFKategori = await _RFKategori.GetByIdAsync(request.KategoriCode, "KategoriCode");
            RFKategori.IsDeleted = true;
            await _RFKategori.UpdateAsync(RFKategori);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}