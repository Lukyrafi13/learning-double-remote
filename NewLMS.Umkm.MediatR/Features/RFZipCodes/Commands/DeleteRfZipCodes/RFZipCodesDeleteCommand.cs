using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodeDeleteCommand : RfZipCodeDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfZipCodeCommandHandler : IRequestHandler<RfZipCodeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public DeleteRfZipCodeCommandHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfZipCodeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfZipCode = await _rfZipCode.GetByIdAsync(request.ZipCode, "ZipCode");

            rfZipCode.DeletedDate = DateTime.Now;
            rfZipCode.IsDeleted = true;

            await _rfZipCode.UpdateAsync(rfZipCode);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
