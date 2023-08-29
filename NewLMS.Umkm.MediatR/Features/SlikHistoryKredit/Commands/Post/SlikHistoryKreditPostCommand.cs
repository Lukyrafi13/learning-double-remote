using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikHistoryKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SlikHistoryKredits.Commands
{
    public class SlikHistoryKreditPostCommand : SlikHistoryKreditPostRequestDto, IRequest<ServiceResponse<SlikHistoryKreditResponseDto>>
    {

    }
    public class SlikHistoryKreditPostCommandHandler : IRequestHandler<SlikHistoryKreditPostCommand, ServiceResponse<SlikHistoryKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikHistoryKredit> _SlikHistoryKredit;
        private readonly IMapper _mapper;

        public SlikHistoryKreditPostCommandHandler(IGenericRepositoryAsync<SlikHistoryKredit> SlikHistoryKredit, IMapper mapper)
        {
            _SlikHistoryKredit = SlikHistoryKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikHistoryKreditResponseDto>> Handle(SlikHistoryKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SlikHistoryKredit = _mapper.Map<SlikHistoryKredit>(request);

                var returnedSlikHistoryKredit = await _SlikHistoryKredit.AddAsync(SlikHistoryKredit, callSave: false);

                // var response = _mapper.Map<SlikHistoryKreditResponseDto>(returnedSlikHistoryKredit);
                var response = _mapper.Map<SlikHistoryKreditResponseDto>(returnedSlikHistoryKredit);

                await _SlikHistoryKredit.SaveChangeAsync();
                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikHistoryKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}