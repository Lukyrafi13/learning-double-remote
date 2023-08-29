using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaTetaps.Commands
{
    public class BiayaTetapPostCommand : BiayaTetapPostRequestDto, IRequest<ServiceResponse<BiayaTetapResponseDto>>
    {

    }
    public class PostBiayaTetapCommandHandler : IRequestHandler<BiayaTetapPostCommand, ServiceResponse<BiayaTetapResponseDto>>
    {
        private readonly IGenericRepositoryAsync<BiayaTetap> _BiayaTetap;
        private readonly IMapper _mapper;

        public PostBiayaTetapCommandHandler(IGenericRepositoryAsync<BiayaTetap> BiayaTetap, IMapper mapper)
        {
            _BiayaTetap = BiayaTetap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BiayaTetapResponseDto>> Handle(BiayaTetapPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var BiayaTetap = _mapper.Map<BiayaTetap>(request);

                var returnedBiayaTetap = await _BiayaTetap.AddAsync(BiayaTetap, callSave: false);

                // var response = _mapper.Map<BiayaTetapResponseDto>(returnedBiayaTetap);
                var response = _mapper.Map<BiayaTetapResponseDto>(returnedBiayaTetap);

                await _BiayaTetap.SaveChangeAsync();
                return ServiceResponse<BiayaTetapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaTetapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}