using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodeDeleteCommand : RFZipCodeDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRFZipCodeCommandHandler : IRequestHandler<RFZipCodeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public DeleteRFZipCodeCommandHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFZipCodeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfZipCode = await _rfZipCode.GetByIdAsync(request.ZipCode, "ZipCode");

            rfZipCode.DeletedDate = DateTime.Now;
            rfZipCode.IsDeleted = true;

            await _rfZipCode.UpdateAsync(rfZipCode);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
