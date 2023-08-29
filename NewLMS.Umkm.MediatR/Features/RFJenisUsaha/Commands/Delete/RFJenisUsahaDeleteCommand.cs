using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Commands
{
    public class RFJenisUsahaDeleteCommand : RFJenisUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJenisUsahaCommandHandler : IRequestHandler<RFJenisUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public DeleteRFJenisUsahaCommandHandler(IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFJenisUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}