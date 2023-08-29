using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Commands
{
    public class RfCompanyTypeDeleteCommand : RfCompanyTypeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRfCompanyTypeCommandHandler : IRequestHandler<RfCompanyTypeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public DeleteRfCompanyTypeCommandHandler(IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCompanyTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfCompanyType.GetByIdAsync(request.AnlCode, "AnlCode");
            rFProduct.IsDeleted = true;
            await _RfCompanyType.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}