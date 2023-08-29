using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.FileDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.FileDokumens.Commands
{
    public class FileDokumenPutCommand : FileDokumenPutRequestDto, IRequest<ServiceResponse<FileDokumenResponseDto>>
    {
    }

    public class PutFileDokumenCommandHandler : IRequestHandler<FileDokumenPutCommand, ServiceResponse<FileDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<FileDokumen> _FileDokumen;
        private readonly IMapper _mapper;

        public PutFileDokumenCommandHandler(IGenericRepositoryAsync<FileDokumen> FileDokumen, IMapper mapper)
        {
            _FileDokumen = FileDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FileDokumenResponseDto>> Handle(FileDokumenPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingFileDokumen = await _FileDokumen.GetByIdAsync(request.Id, "Id");
                existingFileDokumen.DocumentSubType = request.DocumentSubType;
                existingFileDokumen.Active = request.Active;
                existingFileDokumen.PrescreeningDokumenId = request.PrescreeningDokumenId;
                existingFileDokumen.FileUrlId = request.FileUrlId;
                
                await _FileDokumen.UpdateAsync(existingFileDokumen);

                var response = _mapper.Map<FileDokumenResponseDto>(existingFileDokumen);

                return ServiceResponse<FileDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}