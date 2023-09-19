using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3PutCommand : RFSectorLBU3PutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRFSectorLBU3CommandHandler : IRequestHandler<RFSectorLBU3PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public PutRFSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU3PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RFSectorLBU3 = await _rfSectorLBU3.GetByIdAsync(request.Code, "Code");

                RFSectorLBU3.Type = request.Type;
                RFSectorLBU3.Group = request.Group;
                RFSectorLBU3.LBCode2 = request.LBCode2;
                RFSectorLBU3.Description = request.Description;
                RFSectorLBU3.CoreCode = request.CoreCode;
                RFSectorLBU3.CategoryCode = request.CategoryCode;
                RFSectorLBU3.RfSectorLBU2Code = request.RFSectorLBU2Code;

                await _rfSectorLBU3.UpdateAsync(RFSectorLBU3);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
