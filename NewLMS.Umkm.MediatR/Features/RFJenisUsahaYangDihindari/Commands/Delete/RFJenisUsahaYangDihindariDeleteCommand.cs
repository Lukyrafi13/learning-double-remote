using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Commands
{
    public class RfCompanyTypeYangDihindariDeleteCommand : RfCompanyTypeYangDihindariFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRfCompanyTypeYangDihindariCommandHandler : IRequestHandler<RfCompanyTypeYangDihindariDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeYangDihindari> _RfCompanyTypeYangDihindari;
        private readonly IMapper _mapper;

        public DeleteRfCompanyTypeYangDihindariCommandHandler(IGenericRepositoryAsync<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindari, IMapper mapper)
        {
            _RfCompanyTypeYangDihindari = RfCompanyTypeYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCompanyTypeYangDihindariDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfCompanyTypeYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
            rFProduct.IsDeleted = true;
            await _RfCompanyTypeYangDihindari.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}