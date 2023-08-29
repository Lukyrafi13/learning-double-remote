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
    public class RFSatuanLuasPutCommand : RFSatuanLuasPutRequestDto, IRequest<ServiceResponse<RFSatuanLuasResponseDto>>
    {
    }

    public class PutRFSatuanLuasCommandHandler : IRequestHandler<RFSatuanLuasPutCommand, ServiceResponse<RFSatuanLuasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanLuas> _RFSatuanLuas;
        private readonly IMapper _mapper;

        public PutRFSatuanLuasCommandHandler(IGenericRepositoryAsync<RFSatuanLuas> RFSatuanLuas, IMapper mapper)
        {
            _RFSatuanLuas = RFSatuanLuas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSatuanLuasResponseDto>> Handle(RFSatuanLuasPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSatuanLuas = await _RFSatuanLuas.GetByIdAsync(request.SatuanLuas_Id, "SatuanLuas_Id");
                existingRFSatuanLuas.SatuanLuas_Id = request.SatuanLuas_Id;
                existingRFSatuanLuas.SatuanLuas_Desc = request.SatuanLuas_Desc;

                await _RFSatuanLuas.UpdateAsync(existingRFSatuanLuas);

                var response = _mapper.Map<RFSatuanLuasResponseDto>(existingRFSatuanLuas);

                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}