using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFGenders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFGenders.Commands
{
    public class RFGenderPutCommand : RFGenderPutRequestDto, IRequest<ServiceResponse<RFGenderResponseDto>>
    {
    }

    public class PutRFGenderCommandHandler : IRequestHandler<RFGenderPutCommand, ServiceResponse<RFGenderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFGender> _rfGender;
        private readonly IMapper _mapper;

        public PutRFGenderCommandHandler(IGenericRepositoryAsync<RFGender> rfGender, IMapper mapper){
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFGenderResponseDto>> Handle(RFGenderPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFGender = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");
                existingRFGender.Active = true;
                existingRFGender.GenderCode = request.GenderCode;
                existingRFGender.GenderDesc = request.GenderDesc;
                existingRFGender.CoreCode = request.CoreCode;
                existingRFGender.GenderCodeSIKP = request.GenderCodeSIKP;
                existingRFGender.GenderDescSIKP = request.GenderDescSIKP;
                
                await _rfGender.UpdateAsync(existingRFGender);

                var response = new RFGenderResponseDto();
                response.Id = existingRFGender.Id;
                response.GenderCode = existingRFGender.GenderCode;
                response.GenderDesc = existingRFGender.GenderDesc;
                response.CoreCode = existingRFGender.CoreCode;
                response.GenderCodeSIKP = existingRFGender.GenderCodeSIKP;
                response.GenderDescSIKP = existingRFGender.GenderDescSIKP;
                response.Active = existingRFGender.Active;

                return ServiceResponse<RFGenderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFGenderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}