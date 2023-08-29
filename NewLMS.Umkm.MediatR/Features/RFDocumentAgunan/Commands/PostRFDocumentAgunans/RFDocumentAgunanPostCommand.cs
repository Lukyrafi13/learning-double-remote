using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDocumentAgunans.Commands
{
    public class RFDocumentAgunanPostCommand : RFDocumentAgunanPostRequestDto, IRequest<ServiceResponse<RFDocumentAgunanResponseDto>>
    {

    }
    public class PostRFDocumentAgunanCommandHandler : IRequestHandler<RFDocumentAgunanPostCommand, ServiceResponse<RFDocumentAgunanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IMapper _mapper;

        public PostRFDocumentAgunanCommandHandler(IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan, IMapper mapper)
        {
            _RFDocumentAgunan = RFDocumentAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDocumentAgunanResponseDto>> Handle(RFDocumentAgunanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFDocumentAgunan = _mapper.Map<RFDocumentAgunan>(request);

                var returnedRFDocumentAgunan = await _RFDocumentAgunan.AddAsync(RFDocumentAgunan, callSave: false);

                // var response = _mapper.Map<RFDocumentAgunanResponseDto>(returnedRFDocumentAgunan);
                var response = _mapper.Map<RFDocumentAgunanResponseDto>(returnedRFDocumentAgunan);

                await _RFDocumentAgunan.SaveChangeAsync();
                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}