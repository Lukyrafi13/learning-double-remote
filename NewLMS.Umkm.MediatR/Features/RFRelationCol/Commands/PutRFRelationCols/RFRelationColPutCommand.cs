using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRelationCols;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRelationCols.Commands
{
    public class RFRelationColPutCommand : RFRelationColPutRequestDto, IRequest<ServiceResponse<RFRelationColResponseDto>>
    {
    }

    public class PutRFRelationColCommandHandler : IRequestHandler<RFRelationColPutCommand, ServiceResponse<RFRelationColResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFRelationCol> _RFRelationCol;
        private readonly IMapper _mapper;

        public PutRFRelationColCommandHandler(IGenericRepositoryAsync<RFRelationCol> RFRelationCol, IMapper mapper){
            _RFRelationCol = RFRelationCol;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRelationColResponseDto>> Handle(RFRelationColPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFRelationCol = await _RFRelationCol.GetByIdAsync(request.ReCode, "ReCode");
                existingRFRelationCol.ReCode = request.ReCode;
                existingRFRelationCol.ReDesc = request.ReDesc;
                existingRFRelationCol.CoreCode = request.CoreCode;
                existingRFRelationCol.Active = request.Active;
                existingRFRelationCol.Spouse = request.Spouse;
                
                await _RFRelationCol.UpdateAsync(existingRFRelationCol);

                var response = _mapper.Map<RFRelationColResponseDto>(existingRFRelationCol);

                return ServiceResponse<RFRelationColResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationColResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}