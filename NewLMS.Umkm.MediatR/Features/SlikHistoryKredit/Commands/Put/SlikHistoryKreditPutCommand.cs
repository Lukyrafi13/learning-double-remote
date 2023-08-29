using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Commands
{
    public class SlikHistoryKreditPutCommand : SlikHistoryKreditPutRequestDto, IRequest<ServiceResponse<SlikHistoryKreditResponseDto>>
    {
    }

    public class PutSlikHistoryKreditCommandHandler : IRequestHandler<SlikHistoryKreditPutCommand, ServiceResponse<SlikHistoryKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikHistoryKredit> _SlikHistoryKredit;
        private readonly IMapper _mapper;

        public PutSlikHistoryKreditCommandHandler(IGenericRepositoryAsync<SlikHistoryKredit> SlikHistoryKredit, IMapper mapper)
        {
            _SlikHistoryKredit = SlikHistoryKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikHistoryKreditResponseDto>> Handle(SlikHistoryKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSlikHistoryKredit = await _SlikHistoryKredit.GetByIdAsync(request.Id, "Id");
                
                existingSlikHistoryKredit = _mapper.Map<SlikHistoryKreditPutRequestDto, SlikHistoryKredit>(request, existingSlikHistoryKredit);

                await _SlikHistoryKredit.UpdateAsync(existingSlikHistoryKredit);

                var response = _mapper.Map<SlikHistoryKreditResponseDto>(existingSlikHistoryKredit);

                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}