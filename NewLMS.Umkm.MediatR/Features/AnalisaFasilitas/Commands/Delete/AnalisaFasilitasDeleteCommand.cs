using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Commands
{
    public class AnalisaFasilitasDeleteCommand : AnalisaFasilitasFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAnalisaFasilitasCommandHandler : IRequestHandler<AnalisaFasilitasDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public DeleteAnalisaFasilitasCommandHandler(IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas, IMapper mapper){
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AnalisaFasilitasDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AnalisaFasilitas.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AnalisaFasilitas.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}