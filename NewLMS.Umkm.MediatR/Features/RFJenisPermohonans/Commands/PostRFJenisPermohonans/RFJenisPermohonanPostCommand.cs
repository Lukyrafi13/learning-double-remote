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
    public class RFJenisPermohonanPostCommand : RFJenisPermohonanPostRequestDto, IRequest<ServiceResponse<RFJenisPermohonanResponseDto>>
    {

    }
    public class PostRFJenisPermohonanCommandHandler : IRequestHandler<RFJenisPermohonanPostCommand, ServiceResponse<RFJenisPermohonanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisPermohonan> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public PostRFJenisPermohonanCommandHandler(IGenericRepositoryAsync<RFJenisPermohonan> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisPermohonanResponseDto>> Handle(RFJenisPermohonanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfJenisPermohonan = _mapper.Map<RFJenisPermohonan>(request);

                var returnedRfJenisPermohonan = await _rfJenisPermohonan.AddAsync(rfJenisPermohonan, callSave: false);

                var response = _mapper.Map<RFJenisPermohonanResponseDto>(returnedRfJenisPermohonan);

                await _rfJenisPermohonan.SaveChangeAsync();
                return ServiceResponse<RFJenisPermohonanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisPermohonanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}