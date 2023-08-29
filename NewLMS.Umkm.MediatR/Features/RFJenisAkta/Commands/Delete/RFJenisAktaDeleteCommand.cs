using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisAktas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAktas.Commands
{
    public class RFJenisAktaDeleteCommand : RFJenisAktaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisAktaCommandHandler : IRequestHandler<RFJenisAktaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAkta> _RFJenisAkta;
        private readonly IMapper _mapper;

        public DeleteRFJenisAktaCommandHandler(IGenericRepositoryAsync<RFJenisAkta> RFJenisAkta, IMapper mapper){
            _RFJenisAkta = RFJenisAkta;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisAktaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisAkta.GetByIdAsync(request.AktaCode, "AktaCode");
            rFProduct.IsDeleted = true;
            await _RFJenisAkta.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}