using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
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
