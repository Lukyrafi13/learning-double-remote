using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Commands
{
    public class RFJenisLinkAgeDeleteCommand : RFJenisLinkAgeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJenisLinkAgeCommandHandler : IRequestHandler<RFJenisLinkAgeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisLinkAge> _RFJenisLinkAge;
        private readonly IMapper _mapper;

        public DeleteRFJenisLinkAgeCommandHandler(IGenericRepositoryAsync<RFJenisLinkAge> RFJenisLinkAge, IMapper mapper)
        {
            _RFJenisLinkAge = RFJenisLinkAge;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisLinkAgeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisLinkAge.GetByIdAsync(request.JenisLinkAgeCode, "JenisLinkAgeCode");
            rFProduct.IsDeleted = true;
            await _RFJenisLinkAge.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}