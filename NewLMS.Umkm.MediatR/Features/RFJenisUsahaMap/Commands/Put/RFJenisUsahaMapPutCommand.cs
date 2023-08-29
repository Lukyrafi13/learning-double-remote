using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Commands
{
    public class RFJenisUsahaMapPutCommand : RFJenisUsahaMapPutRequestDto, IRequest<ServiceResponse<RFJenisUsahaMapResponseDto>>
    {
    }

    public class PutRFJenisUsahaMapCommandHandler : IRequestHandler<RFJenisUsahaMapPutCommand, ServiceResponse<RFJenisUsahaMapResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
        private readonly IMapper _mapper;

        public PutRFJenisUsahaMapCommandHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaMapResponseDto>> Handle(RFJenisUsahaMapPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisUsahaMap = await _RFJenisUsahaMap.GetByIdAsync(request.Id, "Id");
                existingRFJenisUsahaMap.ANL_CODE = request.ANL_CODE;
                existingRFJenisUsahaMap.KELOMPOK_CODE = request.KELOMPOK_CODE;
                existingRFJenisUsahaMap.PRODUCTID = request.PRODUCTID;

                await _RFJenisUsahaMap.UpdateAsync(existingRFJenisUsahaMap);

                var response = _mapper.Map<RFJenisUsahaMapResponseDto>(existingRFJenisUsahaMap);

                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}