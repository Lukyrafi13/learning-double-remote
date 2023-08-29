using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFGenders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFGenders.Commands
{
    public class RFGenderDeleteCommand : RFGenderFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFGenderCommandHandler : IRequestHandler<RFGenderDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFGender> _rfGender;
        private readonly IMapper _mapper;

        public DeleteRFGenderCommandHandler(IGenericRepositoryAsync<RFGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFGenderDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfGender = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");
            rfGender.IsDeleted = true;
            await _rfGender.UpdateAsync(rfGender);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}