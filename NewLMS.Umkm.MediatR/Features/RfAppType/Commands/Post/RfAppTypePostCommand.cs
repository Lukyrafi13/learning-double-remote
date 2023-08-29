using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Commands
{
    public class RfAppTypePostCommand : RfAppTypePostRequestDto, IRequest<ServiceResponse<RfAppTypeResponseDto>>
    {

    }
    public class PostRfAppTypeCommandHandler : IRequestHandler<RfAppTypePostCommand, ServiceResponse<RfAppTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfAppType> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public PostRfAppTypeCommandHandler(IGenericRepositoryAsync<RfAppType> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfAppTypeResponseDto>> Handle(RfAppTypePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfJenisPermohonan = _mapper.Map<RfAppType>(request);

                var returnedRfJenisPermohonan = await _rfJenisPermohonan.AddAsync(rfJenisPermohonan, callSave: false);

                var response = _mapper.Map<RfAppTypeResponseDto>(returnedRfJenisPermohonan);

                await _rfJenisPermohonan.SaveChangeAsync();
                return ServiceResponse<RfAppTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfAppTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}