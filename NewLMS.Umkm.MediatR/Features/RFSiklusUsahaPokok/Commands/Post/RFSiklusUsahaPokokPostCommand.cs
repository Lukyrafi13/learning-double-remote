using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahaPokoks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSiklusUsahaPokoks.Commands
{
    public class RFSiklusUsahaPokokPostCommand : RFSiklusUsahaPokokPostRequestDto, IRequest<ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {

    }
    public class RFSiklusUsahaPokokPostCommandHandler : IRequestHandler<RFSiklusUsahaPokokPostCommand, ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RFSiklusUsahaPokokPostCommandHandler(IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSiklusUsahaPokokResponseDto>> Handle(RFSiklusUsahaPokokPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSiklusUsahaPokok = _mapper.Map<RFSiklusUsahaPokok>(request);

                var returnedRFSiklusUsahaPokok = await _RFSiklusUsahaPokok.AddAsync(RFSiklusUsahaPokok, callSave: false);

                // var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(returnedRFSiklusUsahaPokok);
                var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(returnedRFSiklusUsahaPokok);

                await _RFSiklusUsahaPokok.SaveChangeAsync();
                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}