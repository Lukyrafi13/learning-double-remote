using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfGenders.Commands
{
    public class RfGenderDeleteCommand : RfGenderFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRfGenderCommandHandler : IRequestHandler<RfGenderDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public DeleteRfGenderCommandHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfGenderDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfGender = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");
            rfGender.IsDeleted = true;
            await _rfGender.UpdateAsync(rfGender);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}