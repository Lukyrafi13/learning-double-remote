using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKategoris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKategoris.Commands
{
    public class RFKategoriPostCommand : RFKategoriPostRequestDto, IRequest<ServiceResponse<RFKategoriResponseDto>>
    {

    }
    public class PostRFKategoriCommandHandler : IRequestHandler<RFKategoriPostCommand, ServiceResponse<RFKategoriResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKategori> _RFKategori;
        private readonly IMapper _mapper;

        public PostRFKategoriCommandHandler(IGenericRepositoryAsync<RFKategori> RFKategori, IMapper mapper)
        {
            _RFKategori = RFKategori;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKategoriResponseDto>> Handle(RFKategoriPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFKategori = _mapper.Map<RFKategori>(request);

                var returnedRfStatusTarget = await _RFKategori.AddAsync(RFKategori, callSave: false);

                // var response = _mapper.Map<RFKategoriResponseDto>(returnedRfStatusTarget);
                var response = _mapper.Map<RFKategoriResponseDto>(returnedRfStatusTarget);

                await _RFKategori.SaveChangeAsync();
                return ServiceResponse<RFKategoriResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKategoriResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}