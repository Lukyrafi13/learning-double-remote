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
    public class RFInsCompanyPutCommand : RFInsCompanyPutRequestDto, IRequest<ServiceResponse<RFInsCompanyResponseDto>>
    {
    }

    public class PutRFInsCompanyCommandHandler : IRequestHandler<RFInsCompanyPutCommand, ServiceResponse<RFInsCompanyResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsCompany> _RFInsCompany;
        private readonly IMapper _mapper;

        public PutRFInsCompanyCommandHandler(IGenericRepositoryAsync<RFInsCompany> RFInsCompany, IMapper mapper)
        {
            _RFInsCompany = RFInsCompany;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsCompanyResponseDto>> Handle(RFInsCompanyPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFInsCompany = await _RFInsCompany.GetByIdAsync(request.CompId, "CompId");
                
                existingRFInsCompany = _mapper.Map<RFInsCompanyPutRequestDto, RFInsCompany>(request, existingRFInsCompany);
                
                await _RFInsCompany.UpdateAsync(existingRFInsCompany);

                var response = _mapper.Map<RFInsCompanyResponseDto>(existingRFInsCompany);

                return ServiceResponse<RFInsCompanyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsCompanyResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}