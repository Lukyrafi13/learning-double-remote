using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Commands
{
    public class RFJenisUsahaYangDihindariDeleteCommand : RFJenisUsahaYangDihindariFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJenisUsahaYangDihindariCommandHandler : IRequestHandler<RFJenisUsahaYangDihindariDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaYangDihindari> _RFJenisUsahaYangDihindari;
        private readonly IMapper _mapper;

        public DeleteRFJenisUsahaYangDihindariCommandHandler(IGenericRepositoryAsync<RFJenisUsahaYangDihindari> RFJenisUsahaYangDihindari, IMapper mapper)
        {
            _RFJenisUsahaYangDihindari = RFJenisUsahaYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisUsahaYangDihindariDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisUsahaYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
            rFProduct.IsDeleted = true;
            await _RFJenisUsahaYangDihindari.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}