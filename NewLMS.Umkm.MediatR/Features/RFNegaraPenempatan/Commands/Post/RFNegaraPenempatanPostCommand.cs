using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanPostCommand : RFNegaraPenempatanPostRequestDto, IRequest<ServiceResponse<RFNegaraPenempatanResponseDto>>
    {

    }
    public class PostRFNegaraPenempatanCommandHandler : IRequestHandler<RFNegaraPenempatanPostCommand, ServiceResponse<RFNegaraPenempatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFNegaraPenempatan> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public PostRFNegaraPenempatanCommandHandler(IGenericRepositoryAsync<RFNegaraPenempatan> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFNegaraPenempatanResponseDto>> Handle(RFNegaraPenempatanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFNegaraPenempatan = _mapper.Map<RFNegaraPenempatan>(request);

                var returnedRFNegaraPenempatan = await _RFNegaraPenempatan.AddAsync(RFNegaraPenempatan, callSave: false);

                // var response = _mapper.Map<RFNegaraPenempatanResponseDto>(returnedRFNegaraPenempatan);
                var response = _mapper.Map<RFNegaraPenempatanResponseDto>(returnedRFNegaraPenempatan);

                await _RFNegaraPenempatan.SaveChangeAsync();
                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}