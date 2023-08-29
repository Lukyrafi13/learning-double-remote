using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSatuanLuass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSatuanLuass.Commands
{
    public class RFSatuanLuasPostCommand : RFSatuanLuasPostRequestDto, IRequest<ServiceResponse<RFSatuanLuasResponseDto>>
    {

    }
    public class PostRFSatuanLuasCommandHandler : IRequestHandler<RFSatuanLuasPostCommand, ServiceResponse<RFSatuanLuasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanLuas> _RFSatuanLuas;
        private readonly IMapper _mapper;

        public PostRFSatuanLuasCommandHandler(IGenericRepositoryAsync<RFSatuanLuas> RFSatuanLuas, IMapper mapper)
        {
            _RFSatuanLuas = RFSatuanLuas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSatuanLuasResponseDto>> Handle(RFSatuanLuasPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSatuanLuas = _mapper.Map<RFSatuanLuas>(request);

                var returnedRFSatuanLuas = await _RFSatuanLuas.AddAsync(RFSatuanLuas, callSave: false);

                // var response = _mapper.Map<RFSatuanLuasResponseDto>(returnedRFSatuanLuas);
                var response = _mapper.Map<RFSatuanLuasResponseDto>(returnedRFSatuanLuas);

                await _RFSatuanLuas.SaveChangeAsync();
                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}