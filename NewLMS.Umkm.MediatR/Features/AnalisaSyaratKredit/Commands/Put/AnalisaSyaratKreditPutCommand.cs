using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Commands
{
    public class AnalisaSyaratKreditPutCommand : AnalisaSyaratKreditPutRequestDto, IRequest<ServiceResponse<AnalisaSyaratKreditResponseDto>>
    {
    }

    public class PutAnalisaSyaratKreditCommandHandler : IRequestHandler<AnalisaSyaratKreditPutCommand, ServiceResponse<AnalisaSyaratKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaSyaratKredit> _AnalisaSyaratKredit;
        private readonly IMapper _mapper;

        public PutAnalisaSyaratKreditCommandHandler(IGenericRepositoryAsync<AnalisaSyaratKredit> AnalisaSyaratKredit, IMapper mapper)
        {
            _AnalisaSyaratKredit = AnalisaSyaratKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaSyaratKreditResponseDto>> Handle(AnalisaSyaratKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAnalisaSyaratKredit = await _AnalisaSyaratKredit.GetByIdAsync(request.Id, "Id");
                existingAnalisaSyaratKredit.Deskripsi = request.Deskripsi;
                existingAnalisaSyaratKredit.By = request.By;
                existingAnalisaSyaratKredit.Catatan = request.Catatan;
                existingAnalisaSyaratKredit.AnalisaId = request.AnalisaId;
                existingAnalisaSyaratKredit.RFJenisSyaratKreditId = request.RFJenisSyaratKreditId;
                existingAnalisaSyaratKredit.RFDecisionSKId = request.RFDecisionSKId;
                existingAnalisaSyaratKredit.Sequence = request.Sequence;
                existingAnalisaSyaratKredit.Verifikasi = request.Verifikasi;

                await _AnalisaSyaratKredit.UpdateAsync(existingAnalisaSyaratKredit);

                var response = _mapper.Map<AnalisaSyaratKreditResponseDto>(existingAnalisaSyaratKredit);

                return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}