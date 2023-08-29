using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2PutCommand : RFSectorLBU2PutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRFSectorLBU2CommandHandler : IRequestHandler<RFSectorLBU2PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public PutRFSectorLBU2CommandHandler(IGenericRepositoryAsync<RFSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU2PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RFSectorLBU2 = await _rfSectorLBU2.GetByIdAsync(request.Code, "Code");

                RFSectorLBU2.LBCode1 = request.LBCode1;
                RFSectorLBU2.Description = request.Description;
                RFSectorLBU2.CoreCode = request.CoreCode;
                RFSectorLBU2.RFSectorLBU1Code = request.RFSectorLBU1Code;

                await _rfSectorLBU2.UpdateAsync(RFSectorLBU2);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int) HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
}
        }
    }
}
