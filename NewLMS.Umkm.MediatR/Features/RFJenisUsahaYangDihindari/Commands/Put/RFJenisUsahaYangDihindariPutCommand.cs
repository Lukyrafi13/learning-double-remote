using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Commands
{
    public class RfCompanyTypeYangDihindariPutCommand : RfCompanyTypeYangDihindariPutRequestDto, IRequest<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {
    }

    public class PutRfCompanyTypeYangDihindariCommandHandler : IRequestHandler<RfCompanyTypeYangDihindariPutCommand, ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeYangDihindari> _RfCompanyTypeYangDihindari;
        private readonly IMapper _mapper;

        public PutRfCompanyTypeYangDihindariCommandHandler(IGenericRepositoryAsync<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindari, IMapper mapper)
        {
            _RfCompanyTypeYangDihindari = RfCompanyTypeYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>> Handle(RfCompanyTypeYangDihindariPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCompanyTypeYangDihindari = await _RfCompanyTypeYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
                existingRfCompanyTypeYangDihindari.StatusJenisUsaha_Code = request.StatusJenisUsaha_Code;
                existingRfCompanyTypeYangDihindari.StatusJenisUsaha_Desc = request.StatusJenisUsaha_Desc;

                await _RfCompanyTypeYangDihindari.UpdateAsync(existingRfCompanyTypeYangDihindari);

                var response = _mapper.Map<RfCompanyTypeYangDihindariResponseDto>(existingRfCompanyTypeYangDihindari);

                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}