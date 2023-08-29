using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.PersiapanAkadAsuransis.Commands
{
    public class PersiapanAkadAsuransiPutCommand : PersiapanAkadAsuransiPutRequestDto, IRequest<ServiceResponse<PersiapanAkadAsuransiResponseDto>>
    {
    }

    public class PutPersiapanAkadAsuransiCommandHandler : IRequestHandler<PersiapanAkadAsuransiPutCommand, ServiceResponse<PersiapanAkadAsuransiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
        private readonly IMapper _mapper;

        public PutPersiapanAkadAsuransiCommandHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper)
        {
            _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PersiapanAkadAsuransiResponseDto>> Handle(PersiapanAkadAsuransiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingPersiapanAkadAsuransi = await _PersiapanAkadAsuransi.GetByIdAsync(request.Id, "Id");
                
                existingPersiapanAkadAsuransi = _mapper.Map<PersiapanAkadAsuransiPutRequestDto, PersiapanAkadAsuransi>(request, existingPersiapanAkadAsuransi);

                await _PersiapanAkadAsuransi.UpdateAsync(existingPersiapanAkadAsuransi);

                var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(existingPersiapanAkadAsuransi);

                return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}