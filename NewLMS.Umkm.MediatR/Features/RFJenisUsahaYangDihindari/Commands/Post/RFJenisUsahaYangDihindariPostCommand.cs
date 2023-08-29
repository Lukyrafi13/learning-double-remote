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
    public class RfCompanyTypeYangDihindariPostCommand : RfCompanyTypeYangDihindariPostRequestDto, IRequest<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {

    }
    public class PostRfCompanyTypeYangDihindariCommandHandler : IRequestHandler<RfCompanyTypeYangDihindariPostCommand, ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyTypeYangDihindari> _RfCompanyTypeYangDihindari;
        private readonly IMapper _mapper;

        public PostRfCompanyTypeYangDihindariCommandHandler(IGenericRepositoryAsync<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindari, IMapper mapper)
        {
            _RfCompanyTypeYangDihindari = RfCompanyTypeYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>> Handle(RfCompanyTypeYangDihindariPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCompanyTypeYangDihindari = _mapper.Map<RfCompanyTypeYangDihindari>(request);

                var returnedRfCompanyTypeYangDihindari = await _RfCompanyTypeYangDihindari.AddAsync(RfCompanyTypeYangDihindari, callSave: false);

                // var response = _mapper.Map<RfCompanyTypeYangDihindariResponseDto>(returnedRfCompanyTypeYangDihindari);
                var response = _mapper.Map<RfCompanyTypeYangDihindariResponseDto>(returnedRfCompanyTypeYangDihindari);

                await _RfCompanyTypeYangDihindari.SaveChangeAsync();
                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}