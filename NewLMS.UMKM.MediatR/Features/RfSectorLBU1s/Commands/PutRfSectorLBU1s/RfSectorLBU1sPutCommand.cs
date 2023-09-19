using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1PutCommand : RFSectorLBU1PutRequest, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class PutRFSectorLBU1CommandHandler : IRequestHandler<RFSectorLBU1PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public PutRFSectorLBU1CommandHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU1PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RFSectorLBU1 = await _rfSectorLBU1.GetByIdAsync(request.Code, "Code");

                RFSectorLBU1.Description = request.Description;
                RFSectorLBU1.CoreCode = request.CoreCode;

                await _rfSectorLBU1.UpdateAsync(RFSectorLBU1);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
