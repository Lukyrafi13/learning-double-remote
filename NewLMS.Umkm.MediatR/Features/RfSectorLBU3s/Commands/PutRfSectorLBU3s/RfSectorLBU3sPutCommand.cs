using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;


namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU3s.Commands
{
    public class RfSectorLBU3PutCommand : RfSectorLBU3PutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRfSectorLBU3CommandHandler : IRequestHandler<RfSectorLBU3PutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public PutRfSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU3PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RfSectorLBU3 = await _rfSectorLBU3.GetByIdAsync(request.Code, "Code");

                RfSectorLBU3.Type = request.Type;
                RfSectorLBU3.Group = request.Group;
                RfSectorLBU3.LBCode2 = request.LBCode2;
                RfSectorLBU3.Description = request.Description;
                RfSectorLBU3.CoreCode = request.CoreCode;
                RfSectorLBU3.CategoryCode = request.CategoryCode;
                RfSectorLBU3.RfSectorLBU2Code = request.RfSectorLBU2Code;

                await _rfSectorLBU3.UpdateAsync(RfSectorLBU3);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
