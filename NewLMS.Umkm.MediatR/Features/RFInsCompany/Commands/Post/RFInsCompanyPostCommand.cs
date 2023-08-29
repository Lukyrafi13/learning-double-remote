using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsCompanys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFInsCompanys.Commands
{
    public class RFInsCompanyPostCommand : RFInsCompanyPostRequestDto, IRequest<ServiceResponse<RFInsCompanyResponseDto>>
    {

    }
    public class RFInsCompanyPostCommandHandler : IRequestHandler<RFInsCompanyPostCommand, ServiceResponse<RFInsCompanyResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsCompany> _RFInsCompany;
        private readonly IMapper _mapper;

        public RFInsCompanyPostCommandHandler(IGenericRepositoryAsync<RFInsCompany> RFInsCompany, IMapper mapper)
        {
            _RFInsCompany = RFInsCompany;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsCompanyResponseDto>> Handle(RFInsCompanyPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFInsCompany = _mapper.Map<RFInsCompany>(request);

                var returnedRFInsCompany = await _RFInsCompany.AddAsync(RFInsCompany, callSave: false);

                // var response = _mapper.Map<RFInsCompanyResponseDto>(returnedRFInsCompany);
                var response = _mapper.Map<RFInsCompanyResponseDto>(returnedRFInsCompany);

                await _RFInsCompany.SaveChangeAsync();
                return ServiceResponse<RFInsCompanyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsCompanyResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}