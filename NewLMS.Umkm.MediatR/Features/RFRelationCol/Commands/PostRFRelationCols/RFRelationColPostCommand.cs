using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationCols;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFRelationCols.Commands
{
    public class RFRelationColPostCommand : RFRelationColPostRequestDto, IRequest<ServiceResponse<RFRelationColResponseDto>>
    {

    }
    public class PostRFRelationColCommandHandler : IRequestHandler<RFRelationColPostCommand, ServiceResponse<RFRelationColResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFRelationCol> _RFRelationCol;
        private readonly IMapper _mapper;

        public PostRFRelationColCommandHandler(IGenericRepositoryAsync<RFRelationCol> RFRelationCol, IMapper mapper)
        {
            _RFRelationCol = RFRelationCol;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRelationColResponseDto>> Handle(RFRelationColPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFRelationCol = _mapper.Map<RFRelationCol>(request);

                var returnedRFRelationCol = await _RFRelationCol.AddAsync(RFRelationCol, callSave: false);

                // var response = _mapper.Map<RFRelationColResponseDto>(returnedRFRelationCol);
                var response = _mapper.Map<RFRelationColResponseDto>(returnedRFRelationCol);

                await _RFRelationCol.SaveChangeAsync();
                return ServiceResponse<RFRelationColResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationColResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}