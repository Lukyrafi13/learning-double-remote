using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Commands
{
    public class RFSiklusUsahaPostCommand : RFSiklusUsahaPostRequestDto, IRequest<ServiceResponse<RFSiklusUsahaResponseDto>>
    {

    }
    public class RFSiklusUsahaPostCommandHandler : IRequestHandler<RFSiklusUsahaPostCommand, ServiceResponse<RFSiklusUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsaha> _RFSiklusUsaha;
        private readonly IMapper _mapper;

        public RFSiklusUsahaPostCommandHandler(IGenericRepositoryAsync<RFSiklusUsaha> RFSiklusUsaha, IMapper mapper)
        {
            _RFSiklusUsaha = RFSiklusUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSiklusUsahaResponseDto>> Handle(RFSiklusUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSiklusUsaha = _mapper.Map<RFSiklusUsaha>(request);

                var returnedRFSiklusUsaha = await _RFSiklusUsaha.AddAsync(RFSiklusUsaha, callSave: false);

                // var response = _mapper.Map<RFSiklusUsahaResponseDto>(returnedRFSiklusUsaha);
                var response = _mapper.Map<RFSiklusUsahaResponseDto>(returnedRFSiklusUsaha);

                await _RFSiklusUsaha.SaveChangeAsync();
                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}