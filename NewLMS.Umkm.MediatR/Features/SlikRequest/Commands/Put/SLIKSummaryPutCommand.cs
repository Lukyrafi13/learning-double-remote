using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikRequests;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SlikRequests.Commands
{
    public class SlikRequestSummaryPutCommand : SlikRequestSummaryPut, IRequest<ServiceResponse<SlikRequestSummaryResponse>>
    {
    }

    public class SlikRequestSummaryPutCommandHandler : IRequestHandler<SlikRequestSummaryPutCommand, ServiceResponse<SlikRequestSummaryResponse>>
    {
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IMapper _mapper;

        public SlikRequestSummaryPutCommandHandler(IGenericRepositoryAsync<SlikRequest> SlikRequest, IMapper mapper)
        {
            _SlikRequest = SlikRequest;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikRequestSummaryResponse>> Handle(SlikRequestSummaryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSlikRequest = await _SlikRequest.GetByIdAsync(request.Id, "Id");
                
                var updatedSlikRequest = _mapper.Map<SlikRequestSummaryPut, SlikRequest>(request, existingSlikRequest);

                await _SlikRequest.UpdateAsync(updatedSlikRequest);

                var response = _mapper.Map<SlikRequestSummaryResponse>(existingSlikRequest);

                return ServiceResponse<SlikRequestSummaryResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikRequestSummaryResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}