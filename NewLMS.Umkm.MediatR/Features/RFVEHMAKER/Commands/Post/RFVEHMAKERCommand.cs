using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Commands
{
    public class RFVEHMAKERPostCommand : RFVEHMAKERPostRequestDto, IRequest<ServiceResponse<RFVEHMAKERResponseDto>>
    {

    }
    public class PostRFVEHMAKERCommandHandler : IRequestHandler<RFVEHMAKERPostCommand, ServiceResponse<RFVEHMAKERResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHMAKER> _RFVEHMAKER;
        private readonly IMapper _mapper;

        public PostRFVEHMAKERCommandHandler(IGenericRepositoryAsync<RFVEHMAKER> RFVEHMAKER, IMapper mapper)
        {
            _RFVEHMAKER = RFVEHMAKER;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHMAKERResponseDto>> Handle(RFVEHMAKERPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFVEHMAKER = _mapper.Map<RFVEHMAKER>(request);

                var returnedRFVEHMAKER = await _RFVEHMAKER.AddAsync(RFVEHMAKER, callSave: false);

                // var response = _mapper.Map<RFVEHMAKERResponseDto>(returnedRFVEHMAKER);
                var response = _mapper.Map<RFVEHMAKERResponseDto>(returnedRFVEHMAKER);

                await _RFVEHMAKER.SaveChangeAsync();
                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}