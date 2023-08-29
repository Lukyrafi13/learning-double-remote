using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisTempatUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisTempatUsahas.Commands
{
    public class RFJenisTempatUsahaDeleteCommand : RFJenisTempatUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJenisTempatUsahaCommandHandler : IRequestHandler<RFJenisTempatUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisTempatUsaha> _RFJenisTempatUsaha;
        private readonly IMapper _mapper;

        public DeleteRFJenisTempatUsahaCommandHandler(IGenericRepositoryAsync<RFJenisTempatUsaha> RFJenisTempatUsaha, IMapper mapper)
        {
            _RFJenisTempatUsaha = RFJenisTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisTempatUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFJenisTempatUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}