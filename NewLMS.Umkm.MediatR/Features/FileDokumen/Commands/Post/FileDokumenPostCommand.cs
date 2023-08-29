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
    public class FileDokumenPostCommand : FileDokumenPostRequestDto, IRequest<ServiceResponse<FileDokumenResponseDto>>
    {

    }
    public class FileDokumenPostCommandHandler : IRequestHandler<FileDokumenPostCommand, ServiceResponse<FileDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<FileDokumen> _FileDokumen;
        private readonly IMapper _mapper;

        public FileDokumenPostCommandHandler(IGenericRepositoryAsync<FileDokumen> FileDokumen, IMapper mapper)
        {
            _FileDokumen = FileDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FileDokumenResponseDto>> Handle(FileDokumenPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var FileDokumen = _mapper.Map<FileDokumen>(request);

                var returnedFileDokumen = await _FileDokumen.AddAsync(FileDokumen, callSave: false);

                // var response = _mapper.Map<FileDokumenResponseDto>(returnedFileDokumen);
                var response = _mapper.Map<FileDokumenResponseDto>(returnedFileDokumen);

                await _FileDokumen.SaveChangeAsync();
                return ServiceResponse<FileDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}