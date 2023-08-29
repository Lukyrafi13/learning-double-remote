using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPolaPengembalians;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPolaPengembalians.Commands
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