using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfGenders.Commands
{
    public class RfGenderPutCommand : RfGenderPutRequestDto, IRequest<ServiceResponse<RfGenderResponseDto>>
    {
    }

    public class PutRfGenderCommandHandler : IRequestHandler<RfGenderPutCommand, ServiceResponse<RfGenderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public PutRfGenderCommandHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper){
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfGenderResponseDto>> Handle(RfGenderPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfGender = await _rfGender.GetByIdAsync(request.GenderCode, "GenderCode");
                existingRfGender.Active = true;
                existingRfGender.GenderCode = request.GenderCode;
                existingRfGender.GenderDesc = request.GenderDesc;
                existingRfGender.CoreCode = request.CoreCode;
                existingRfGender.GenderCodeSIKP = request.GenderCodeSIKP;
                existingRfGender.GenderDescSIKP = request.GenderDescSIKP;
                
                await _rfGender.UpdateAsync(existingRfGender);

                var response = new RfGenderResponseDto();
                response.Id = existingRfGender.Id;
                response.GenderCode = existingRfGender.GenderCode;
                response.GenderDesc = existingRfGender.GenderDesc;
                response.CoreCode = existingRfGender.CoreCode;
                response.GenderCodeSIKP = existingRfGender.GenderCodeSIKP;
                response.GenderDescSIKP = existingRfGender.GenderDescSIKP;
                response.Active = existingRfGender.Active;

                return ServiceResponse<RfGenderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfGenderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}