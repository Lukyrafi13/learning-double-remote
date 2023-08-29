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
    public class RFKategoriPutCommand : RFKategoriPutRequestDto, IRequest<ServiceResponse<RFKategoriResponseDto>>
    {
    }

    public class PutRFKategoriCommandHandler : IRequestHandler<RFKategoriPutCommand, ServiceResponse<RFKategoriResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKategori> _RFKategori;
        private readonly IMapper _mapper;

        public PutRFKategoriCommandHandler(IGenericRepositoryAsync<RFKategori> RFKategori, IMapper mapper){
            _RFKategori = RFKategori;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKategoriResponseDto>> Handle(RFKategoriPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFKategori = await _RFKategori.GetByIdAsync(request.KategoriCode, "KategoriCode");
                existingRFKategori.KategoriCode = request.KategoriCode;
                existingRFKategori.KategoriDesc = request.KategoriDesc;
                existingRFKategori.Active = request.Active;
                
                await _RFKategori.UpdateAsync(existingRFKategori);
                
                var response = _mapper.Map<RFKategoriResponseDto>(existingRFKategori);

                return ServiceResponse<RFKategoriResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKategoriResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}