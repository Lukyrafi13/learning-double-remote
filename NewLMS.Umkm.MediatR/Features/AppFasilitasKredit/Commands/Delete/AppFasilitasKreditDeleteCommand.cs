using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppFasilitasKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppFasilitasKredits.Commands
{
    public class AppFasilitasKreditDeleteCommand : AppFasilitasKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAppFasilitasKreditCommandHandler : IRequestHandler<AppFasilitasKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
        private readonly IMapper _mapper;

        public DeleteAppFasilitasKreditCommandHandler(IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit, IMapper mapper){
            _AppFasilitasKredit = AppFasilitasKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppFasilitasKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AppFasilitasKredit.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AppFasilitasKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}