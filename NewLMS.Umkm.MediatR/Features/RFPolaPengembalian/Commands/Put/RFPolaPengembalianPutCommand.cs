using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPolaPengembalians;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPolaPengembalians.Commands
{
    public class RFPolaPengembalianPutCommand : RFPolaPengembalianPutRequestDto, IRequest<ServiceResponse<RFPolaPengembalianResponseDto>>
    {
    }

    public class PutRFPolaPengembalianCommandHandler : IRequestHandler<RFPolaPengembalianPutCommand, ServiceResponse<RFPolaPengembalianResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPolaPengembalian> _RFPolaPengembalian;
        private readonly IMapper _mapper;

        public PutRFPolaPengembalianCommandHandler(IGenericRepositoryAsync<RFPolaPengembalian> RFPolaPengembalian, IMapper mapper)
        {
            _RFPolaPengembalian = RFPolaPengembalian;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPolaPengembalianResponseDto>> Handle(RFPolaPengembalianPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFPolaPengembalian = await _RFPolaPengembalian.GetByIdAsync(request.PolaCode, "PolaCode");
                
                existingRFPolaPengembalian.PolaDesc = request.PolaDesc;
                existingRFPolaPengembalian.Active = request.Active;
                await _RFPolaPengembalian.UpdateAsync(existingRFPolaPengembalian);

                var response = _mapper.Map<RFPolaPengembalianResponseDto>(existingRFPolaPengembalian);

                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}