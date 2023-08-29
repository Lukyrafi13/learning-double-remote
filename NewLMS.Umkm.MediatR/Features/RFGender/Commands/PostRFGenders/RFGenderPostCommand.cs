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
    public class RFGenderPostCommand : RFGenderPostRequestDto, IRequest<ServiceResponse<RFGenderResponseDto>>
    {

    }
    public class PostRFGenderCommandHandler : IRequestHandler<RFGenderPostCommand, ServiceResponse<RFGenderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFGender> _rfGender;
        private readonly IMapper _mapper;

        public PostRFGenderCommandHandler(IGenericRepositoryAsync<RFGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFGenderResponseDto>> Handle(RFGenderPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfGender = new RFGender();

                rfGender.Active = true;
                rfGender.GenderCode = request.GenderCode;
                rfGender.GenderDesc = request.GenderDesc;
                rfGender.CoreCode = request.CoreCode;
                rfGender.GenderCodeSIKP = request.GenderCodeSIKP;
                rfGender.GenderDescSIKP = request.GenderDescSIKP;

                var returnedRfStatusTarget = await _rfGender.AddAsync(rfGender, callSave: false);

                // var response = _mapper.Map<RFGenderResponseDto>(returnedRfStatusTarget);
                var response = new RFGenderResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.GenderCode = returnedRfStatusTarget.GenderCode;
                response.GenderDesc = returnedRfStatusTarget.GenderDesc;
                response.CoreCode = returnedRfStatusTarget.CoreCode;
                response.GenderCodeSIKP = returnedRfStatusTarget.GenderCodeSIKP;
                response.GenderDescSIKP = returnedRfStatusTarget.GenderDescSIKP;
                response.Active = returnedRfStatusTarget.Active;

                await _rfGender.SaveChangeAsync();
                return ServiceResponse<RFGenderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFGenderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}