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
    public class RfGenderPostCommand : RfGenderPostRequestDto, IRequest<ServiceResponse<RfGenderResponseDto>>
    {

    }
    public class PostRfGenderCommandHandler : IRequestHandler<RfGenderPostCommand, ServiceResponse<RfGenderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public PostRfGenderCommandHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfGenderResponseDto>> Handle(RfGenderPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfGender = new RfGender();

                rfGender.Active = true;
                rfGender.GenderCode = request.GenderCode;
                rfGender.GenderDesc = request.GenderDesc;
                rfGender.CoreCode = request.CoreCode;
                rfGender.GenderCodeSIKP = request.GenderCodeSIKP;
                rfGender.GenderDescSIKP = request.GenderDescSIKP;

                var returnedRfStatusTarget = await _rfGender.AddAsync(rfGender, callSave: false);

                // var response = _mapper.Map<RfGenderResponseDto>(returnedRfStatusTarget);
                var response = new RfGenderResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.GenderCode = returnedRfStatusTarget.GenderCode;
                response.GenderDesc = returnedRfStatusTarget.GenderDesc;
                response.CoreCode = returnedRfStatusTarget.CoreCode;
                response.GenderCodeSIKP = returnedRfStatusTarget.GenderCodeSIKP;
                response.GenderDescSIKP = returnedRfStatusTarget.GenderDescSIKP;
                response.Active = returnedRfStatusTarget.Active;

                await _rfGender.SaveChangeAsync();
                return ServiceResponse<RfGenderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfGenderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}