using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanLuass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanLuass.Commands
{
    public class RFSatuanLuasDeleteCommand : RFSatuanLuasFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSatuanLuasCommandHandler : IRequestHandler<RFSatuanLuasDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanLuas> _RFSatuanLuas;
        private readonly IMapper _mapper;

        public DeleteRFSatuanLuasCommandHandler(IGenericRepositoryAsync<RFSatuanLuas> RFSatuanLuas, IMapper mapper)
        {
            _RFSatuanLuas = RFSatuanLuas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSatuanLuasDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSatuanLuas.GetByIdAsync(request.SatuanLuas_Id, "SatuanLuas_Id");
            rFProduct.IsDeleted = true;
            await _RFSatuanLuas.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}