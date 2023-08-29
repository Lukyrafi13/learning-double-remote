using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1PutCommand : RfSectorLBU1PutRequest, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class PutRfSectorLBU1CommandHandler : IRequestHandler<RfSectorLBU1PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public PutRfSectorLBU1CommandHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU1PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RfSectorLBU1 = await _rfSectorLBU1.GetByIdAsync(request.Code, "Code");

                RfSectorLBU1.Description = request.Description;
                RfSectorLBU1.CoreCode = request.CoreCode;

                await _rfSectorLBU1.UpdateAsync(RfSectorLBU1);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
