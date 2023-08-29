using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppKeyPersons;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppKeyPersons.Commands
{
    public class AppKeyPersonDeleteCommand : AppKeyPersonFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteAppKeyPersonCommandHandler : IRequestHandler<AppKeyPersonDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
        private readonly IMapper _mapper;

        public DeleteAppKeyPersonCommandHandler(IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson, IMapper mapper){
            _AppKeyPerson = AppKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppKeyPersonDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _AppKeyPerson.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _AppKeyPerson.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}