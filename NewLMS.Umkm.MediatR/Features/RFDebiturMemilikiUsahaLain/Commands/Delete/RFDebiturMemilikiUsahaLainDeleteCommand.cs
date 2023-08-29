using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands
{
    public class RFDebiturMemilikiUsahaLainDeleteCommand : RFDebiturMemilikiUsahaLainFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFDebiturMemilikiUsahaLainCommandHandler : IRequestHandler<RFDebiturMemilikiUsahaLainDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<DebiturMemilikiUsahaLain> _RFDebiturMemilikiUsahaLain;
        private readonly IMapper _mapper;

        public DeleteRFDebiturMemilikiUsahaLainCommandHandler(IGenericRepositoryAsync<DebiturMemilikiUsahaLain> RFDebiturMemilikiUsahaLain, IMapper mapper)
        {
            _RFDebiturMemilikiUsahaLain = RFDebiturMemilikiUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFDebiturMemilikiUsahaLainDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFDebiturMemilikiUsahaLain.GetByIdAsync(request.StatusDebitur_Code, "StatusDebitur_Code");
            rFProduct.IsDeleted = true;
            await _RFDebiturMemilikiUsahaLain.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}