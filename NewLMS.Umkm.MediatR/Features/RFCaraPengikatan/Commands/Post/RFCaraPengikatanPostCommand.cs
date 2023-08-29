using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFCaraPengikatans.Commands
{
    public class RFCaraPengikatanPostCommand : RFCaraPengikatanPostRequestDto, IRequest<ServiceResponse<RFCaraPengikatanResponseDto>>
    {

    }
    public class PostRFCaraPengikatanCommandHandler : IRequestHandler<RFCaraPengikatanPostCommand, ServiceResponse<RFCaraPengikatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCaraPengikatan> _RFCaraPengikatan;
        private readonly IMapper _mapper;

        public PostRFCaraPengikatanCommandHandler(IGenericRepositoryAsync<RFCaraPengikatan> RFCaraPengikatan, IMapper mapper)
        {
            _RFCaraPengikatan = RFCaraPengikatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCaraPengikatanResponseDto>> Handle(RFCaraPengikatanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFCaraPengikatan = _mapper.Map<RFCaraPengikatan>(request);

                var returnedRFCaraPengikatan = await _RFCaraPengikatan.AddAsync(RFCaraPengikatan, callSave: false);

                // var response = _mapper.Map<RFCaraPengikatanResponseDto>(returnedRFCaraPengikatan);
                var response = _mapper.Map<RFCaraPengikatanResponseDto>(returnedRFCaraPengikatan);

                await _RFCaraPengikatan.SaveChangeAsync();
                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}