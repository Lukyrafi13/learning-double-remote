using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Commands
{
    public class RFJenisPermohonanPutCommand : RFJenisPermohonanPutRequestDto, IRequest<ServiceResponse<RFJenisPermohonanResponseDto>>
    {
    }

    public class PutRFJenisPermohonanCommandHandler : IRequestHandler<RFJenisPermohonanPutCommand, ServiceResponse<RFJenisPermohonanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisPermohonan> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public PutRFJenisPermohonanCommandHandler(IGenericRepositoryAsync<RFJenisPermohonan> rfJenisPermohonan, IMapper mapper){
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisPermohonanResponseDto>> Handle(RFJenisPermohonanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisPermohonan = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");
                
                existingRFJenisPermohonan.JenisPermohonan = request.JenisPermohonan;
                
                await _rfJenisPermohonan.UpdateAsync(existingRFJenisPermohonan);

                var response = _mapper.Map<RFJenisPermohonanResponseDto>(existingRFJenisPermohonan);

                return ServiceResponse<RFJenisPermohonanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisPermohonanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}