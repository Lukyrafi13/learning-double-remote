using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Commands
{
    public class RFMappingLBU3PutCommand : RFMappingLBU3PutRequestDto, IRequest<ServiceResponse<RFMappingLBU3ResponseDto>>
    {
    }

    public class PutRFMappingLBU3CommandHandler : IRequestHandler<RFMappingLBU3PutCommand, ServiceResponse<RFMappingLBU3ResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public PutRFMappingLBU3CommandHandler(IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3, IMapper mapper)
        {
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingLBU3ResponseDto>> Handle(RFMappingLBU3PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFMappingLBU3 = await _RFMappingLBU3.GetByIdAsync(request.Id, "Id");
                
                existingRFMappingLBU3.LBU3Code = request.LBU3Code;
                existingRFMappingLBU3.ProductId = request.ProductId;

                await _RFMappingLBU3.UpdateAsync(existingRFMappingLBU3);

                var response = _mapper.Map<RFMappingLBU3ResponseDto>(existingRFMappingLBU3);

                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}