using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprKomoditis.Commands
{
    public class RFApprKomoditiPostCommand : RFApprKomoditiPostRequestDto, IRequest<ServiceResponse<RFApprKomoditiResponseDto>>
    {

    }
    public class PostRFApprKomoditiCommandHandler : IRequestHandler<RFApprKomoditiPostCommand, ServiceResponse<RFApprKomoditiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprKomoditi> _RFApprKomoditi;
        private readonly IMapper _mapper;

        public PostRFApprKomoditiCommandHandler(IGenericRepositoryAsync<RFApprKomoditi> RFApprKomoditi, IMapper mapper)
        {
            _RFApprKomoditi = RFApprKomoditi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprKomoditiResponseDto>> Handle(RFApprKomoditiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFApprKomoditi = _mapper.Map<RFApprKomoditi>(request);

                var returnedRFApprKomoditi = await _RFApprKomoditi.AddAsync(RFApprKomoditi, callSave: false);

                // var response = _mapper.Map<RFApprKomoditiResponseDto>(returnedRFApprKomoditi);
                var response = _mapper.Map<RFApprKomoditiResponseDto>(returnedRFApprKomoditi);

                await _RFApprKomoditi.SaveChangeAsync();
                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}