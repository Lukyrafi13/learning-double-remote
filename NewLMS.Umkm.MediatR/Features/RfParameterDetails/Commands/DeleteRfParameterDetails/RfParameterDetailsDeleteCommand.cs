using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Helper;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.DeleteRfParameterDetails
{
    public class RfParameterDetailDeleteCommand : RfParameterDetailDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfParameterDetailCommandHandler : IRequestHandler<RfParameterDetailDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameterDetail> _subProduct;
        private readonly IMapper _mapper;

        public DeleteRfParameterDetailCommandHandler(IGenericRepositoryAsync<RfParameterDetail> subProduct, IMapper mapper)
        {
            _subProduct = subProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            var subProduct = await _subProduct.GetByIdAsync(request.ParameterDetailId, "ParameterDetailId");

            subProduct.DeletedDate = DateTime.Now;
            subProduct.IsDeleted = true;

            await _subProduct.UpdateAsync(subProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
