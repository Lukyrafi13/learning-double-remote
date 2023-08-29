using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaPinjamanDariBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaPinjamanDariBanks.Commands
{
    public class AnalisaPinjamanDariBankDeleteCommand : AnalisaPinjamanDariBankFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAnalisaPinjamanDariBankCommandHandler : IRequestHandler<AnalisaPinjamanDariBankDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public DeleteAnalisaPinjamanDariBankCommandHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper){
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AnalisaPinjamanDariBankDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AnalisaPinjamanDariBank.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AnalisaPinjamanDariBank.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}