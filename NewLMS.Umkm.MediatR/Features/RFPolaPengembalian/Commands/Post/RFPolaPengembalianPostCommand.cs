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
    public class RFPolaPengembalianPostCommand : RFPolaPengembalianPostRequestDto, IRequest<ServiceResponse<RFPolaPengembalianResponseDto>>
    {

    }
    public class RFPolaPengembalianPostCommandHandler : IRequestHandler<RFPolaPengembalianPostCommand, ServiceResponse<RFPolaPengembalianResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPolaPengembalian> _RFPolaPengembalian;
        private readonly IMapper _mapper;

        public RFPolaPengembalianPostCommandHandler(IGenericRepositoryAsync<RFPolaPengembalian> RFPolaPengembalian, IMapper mapper)
        {
            _RFPolaPengembalian = RFPolaPengembalian;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPolaPengembalianResponseDto>> Handle(RFPolaPengembalianPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFPolaPengembalian = _mapper.Map<RFPolaPengembalian>(request);

                var returnedRFPolaPengembalian = await _RFPolaPengembalian.AddAsync(RFPolaPengembalian, callSave: false);

                // var response = _mapper.Map<RFPolaPengembalianResponseDto>(returnedRFPolaPengembalian);
                var response = _mapper.Map<RFPolaPengembalianResponseDto>(returnedRFPolaPengembalian);

                await _RFPolaPengembalian.SaveChangeAsync();
                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}