using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Commands
{
    public class RfCompanyTypeMapDeleteCommand : RfCompanyTypeMapFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRfCompanyTypeMapCommandHandler : IRequestHandler<RfCompanyTypeMapDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
        private readonly IMapper _mapper;

        public DeleteRfCompanyTypeMapCommandHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCompanyTypeMapDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfCompanyTypeMap.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RfCompanyTypeMap.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}