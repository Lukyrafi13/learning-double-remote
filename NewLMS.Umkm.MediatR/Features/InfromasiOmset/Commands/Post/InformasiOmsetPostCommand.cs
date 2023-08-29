using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.InformasiOmsets;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.InformasiOmsets.Commands
{
    public class InformasiOmsetPostCommand : InformasiOmsetPostRequestDto, IRequest<ServiceResponse<InformasiOmsetResponseDto>>
    {

    }
    public class PostInformasiOmsetCommandHandler : IRequestHandler<InformasiOmsetPostCommand, ServiceResponse<InformasiOmsetResponseDto>>
    {
        private readonly IGenericRepositoryAsync<InformasiOmset> _InformasiOmset;
        private readonly IMapper _mapper;

        public PostInformasiOmsetCommandHandler(IGenericRepositoryAsync<InformasiOmset> InformasiOmset, IMapper mapper)
        {
            _InformasiOmset = InformasiOmset;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<InformasiOmsetResponseDto>> Handle(InformasiOmsetPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var InformasiOmset = _mapper.Map<InformasiOmset>(request);

                var returnedInformasiOmset = await _InformasiOmset.AddAsync(InformasiOmset, callSave: false);

                // var response = _mapper.Map<InformasiOmsetResponseDto>(returnedInformasiOmset);
                var response = _mapper.Map<InformasiOmsetResponseDto>(returnedInformasiOmset);

                await _InformasiOmset.SaveChangeAsync();
                return ServiceResponse<InformasiOmsetResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<InformasiOmsetResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}