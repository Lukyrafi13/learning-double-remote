using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Commands
{
    public class RfSectorLBU2PutCommand : RfSectorLBU2PutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRfSectorLBU2CommandHandler : IRequestHandler<RfSectorLBU2PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public PutRfSectorLBU2CommandHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU2PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RfSectorLBU2 = await _rfSectorLBU2.GetByIdAsync(request.Code, "Code");

                RfSectorLBU2.LBCode1 = request.LBCode1;
                RfSectorLBU2.Description = request.Description;
                RfSectorLBU2.CoreCode = request.CoreCode;
                RfSectorLBU2.RfSectorLBU1Code = request.RfSectorLBU1Code;

                await _rfSectorLBU2.UpdateAsync(RfSectorLBU2);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int) HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
}
        }
    }
}
