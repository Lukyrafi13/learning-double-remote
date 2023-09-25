using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands
{
    public class SLIKRequestDebtorPostCommand : SLIKRequestDebtorRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class SLIKRequestDebtorPostCommandHandler : IRequestHandler<SLIKRequestDebtorPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly IMapper _mapper;

        public SLIKRequestDebtorPostCommandHandler(IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, IMapper mapper)
        {
            _slikRequestDebtor = slikRequestDebtor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestDebtorPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequestDebtor = _mapper.Map<SLIKRequestDebtor>(request);
                await _slikRequestDebtor.AddAsync(slikRequestDebtor);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
