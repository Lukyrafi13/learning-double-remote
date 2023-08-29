using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisKendaraanAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisKendaraanAgunans.Commands
{
    public class RFJenisKendaraanAgunanDeleteCommand : RFJenisKendaraanAgunanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisKendaraanAgunanCommandHandler : IRequestHandler<RFJenisKendaraanAgunanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisKendaraanAgunan> _RFJenisKendaraanAgunan;
        private readonly IMapper _mapper;

        public DeleteRFJenisKendaraanAgunanCommandHandler(IGenericRepositoryAsync<RFJenisKendaraanAgunan> RFJenisKendaraanAgunan, IMapper mapper){
            _RFJenisKendaraanAgunan = RFJenisKendaraanAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisKendaraanAgunanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisKendaraanAgunan.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
            rFProduct.IsDeleted = true;
            await _RFJenisKendaraanAgunan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}