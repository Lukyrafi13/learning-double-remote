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
    public class InformasiOmsetPutCommand : InformasiOmsetPutRequestDto, IRequest<ServiceResponse<InformasiOmsetResponseDto>>
    {
    }

    public class PutInformasiOmsetCommandHandler : IRequestHandler<InformasiOmsetPutCommand, ServiceResponse<InformasiOmsetResponseDto>>
    {
        private readonly IGenericRepositoryAsync<InformasiOmset> _InformasiOmset;
        private readonly IMapper _mapper;

        public PutInformasiOmsetCommandHandler(IGenericRepositoryAsync<InformasiOmset> InformasiOmset, IMapper mapper)
        {
            _InformasiOmset = InformasiOmset;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<InformasiOmsetResponseDto>> Handle(InformasiOmsetPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingInformasiOmset = await _InformasiOmset.GetByIdAsync(request.Id, "Id");
                
                existingInformasiOmset = _mapper.Map<InformasiOmsetPutRequestDto, InformasiOmset>(request, existingInformasiOmset);
                
                await _InformasiOmset.UpdateAsync(existingInformasiOmset);

                var response = _mapper.Map<InformasiOmsetResponseDto>(existingInformasiOmset);

                return ServiceResponse<InformasiOmsetResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<InformasiOmsetResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}