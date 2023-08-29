using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBuktiKepemilikans.Commands
{
    public class RFBuktiKepemilikanPostCommand : RFBuktiKepemilikanPostRequestDto, IRequest<ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {

    }
    public class PostRFBuktiKepemilikanCommandHandler : IRequestHandler<RFBuktiKepemilikanPostCommand, ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBuktiKepemilikan> _RFBuktiKepemilikan;
        private readonly IMapper _mapper;

        public PostRFBuktiKepemilikanCommandHandler(IGenericRepositoryAsync<RFBuktiKepemilikan> RFBuktiKepemilikan, IMapper mapper)
        {
            _RFBuktiKepemilikan = RFBuktiKepemilikan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBuktiKepemilikanResponseDto>> Handle(RFBuktiKepemilikanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBuktiKepemilikan = _mapper.Map<RFBuktiKepemilikan>(request);

                var returnedRFBuktiKepemilikan = await _RFBuktiKepemilikan.AddAsync(RFBuktiKepemilikan, callSave: false);

                // var response = _mapper.Map<RFBuktiKepemilikanResponseDto>(returnedRFBuktiKepemilikan);
                var response = _mapper.Map<RFBuktiKepemilikanResponseDto>(returnedRFBuktiKepemilikan);

                await _RFBuktiKepemilikan.SaveChangeAsync();
                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}