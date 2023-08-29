using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Commands
{
    public class PrescreeningDokumenDeleteCommand : PrescreeningDokumenFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeletePrescreeningDokumenCommandHandler : IRequestHandler<PrescreeningDokumenDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
        private readonly IMapper _mapper;

        public DeletePrescreeningDokumenCommandHandler(
            IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen, 
            IMapper mapper
        )
        {
            _PrescreeningDokumen = PrescreeningDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PrescreeningDokumenDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _PrescreeningDokumen.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _PrescreeningDokumen.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}