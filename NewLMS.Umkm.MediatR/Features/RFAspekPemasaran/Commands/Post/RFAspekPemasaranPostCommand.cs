using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFAspekPemasarans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFAspekPemasarans.Commands
{
    public class RFAspekPemasaranPostCommand : RFAspekPemasaranPostRequestDto, IRequest<ServiceResponse<RFAspekPemasaranResponseDto>>
    {

    }
    public class PostRFAspekPemasaranCommandHandler : IRequestHandler<RFAspekPemasaranPostCommand, ServiceResponse<RFAspekPemasaranResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFAspekPemasaran> _RFAspekPemasaran;
        private readonly IMapper _mapper;

        public PostRFAspekPemasaranCommandHandler(IGenericRepositoryAsync<RFAspekPemasaran> RFAspekPemasaran, IMapper mapper)
        {
            _RFAspekPemasaran = RFAspekPemasaran;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFAspekPemasaranResponseDto>> Handle(RFAspekPemasaranPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFAspekPemasaran = _mapper.Map<RFAspekPemasaran>(request);

                var returnedRFAspekPemasaran = await _RFAspekPemasaran.AddAsync(RFAspekPemasaran, callSave: false);

                // var response = _mapper.Map<RFAspekPemasaranResponseDto>(returnedRFAspekPemasaran);
                var response = _mapper.Map<RFAspekPemasaranResponseDto>(returnedRFAspekPemasaran);

                await _RFAspekPemasaran.SaveChangeAsync();
                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}