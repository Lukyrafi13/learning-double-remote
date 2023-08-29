using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaAsuransis.Commands
{
    public class AnalisaAsuransiDeleteCommand : AnalisaAsuransiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAnalisaAsuransiCommandHandler : IRequestHandler<AnalisaAsuransiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
        private readonly IMapper _mapper;

        public DeleteAnalisaAsuransiCommandHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper){
            _AnalisaAsuransi = AnalisaAsuransi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AnalisaAsuransiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AnalisaAsuransi.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AnalisaAsuransi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}