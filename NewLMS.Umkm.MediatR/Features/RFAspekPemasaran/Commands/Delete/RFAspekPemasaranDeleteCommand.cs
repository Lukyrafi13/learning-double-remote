using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Commands
{
    public class RFAspekPemasaranDeleteCommand : RFAspekPemasaranFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFAspekPemasaranCommandHandler : IRequestHandler<RFAspekPemasaranDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFAspekPemasaran> _RFAspekPemasaran;
        private readonly IMapper _mapper;

        public DeleteRFAspekPemasaranCommandHandler(IGenericRepositoryAsync<RFAspekPemasaran> RFAspekPemasaran, IMapper mapper)
        {
            _RFAspekPemasaran = RFAspekPemasaran;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFAspekPemasaranDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFAspekPemasaran.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFAspekPemasaran.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}