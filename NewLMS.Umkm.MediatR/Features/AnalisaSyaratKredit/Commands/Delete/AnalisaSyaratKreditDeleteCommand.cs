using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Commands
{
    public class AnalisaSyaratKreditDeleteCommand : AnalisaSyaratKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAnalisaSyaratKreditCommandHandler : IRequestHandler<AnalisaSyaratKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AnalisaSyaratKredit> _AnalisaSyaratKredit;
        private readonly IMapper _mapper;

        public DeleteAnalisaSyaratKreditCommandHandler(IGenericRepositoryAsync<AnalisaSyaratKredit> AnalisaSyaratKredit, IMapper mapper){
            _AnalisaSyaratKredit = AnalisaSyaratKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AnalisaSyaratKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AnalisaSyaratKredit.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AnalisaSyaratKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}