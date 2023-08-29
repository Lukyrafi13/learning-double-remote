using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SIKPCalonDebiturs.Commands
{
    public class SIKPCalonDebiturPostCommand : SIKPCalonDebiturPostRequestDto, IRequest<ServiceResponse<SIKPCalonDebiturResponseDto>>
    {

    }
    public class SIKPCalonDebiturPostCommandHandler : IRequestHandler<SIKPCalonDebiturPostCommand, ServiceResponse<SIKPCalonDebiturResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private readonly IMapper _mapper;

        public SIKPCalonDebiturPostCommandHandler(IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur, IMapper mapper)
        {
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPCalonDebiturResponseDto>> Handle(SIKPCalonDebiturPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SIKPCalonDebitur = _mapper.Map<SIKPCalonDebitur>(request);

                var returnedSIKPCalonDebitur = await _SIKPCalonDebitur.AddAsync(SIKPCalonDebitur, callSave: false);

                // var response = _mapper.Map<SIKPCalonDebiturResponseDto>(returnedSIKPCalonDebitur);
                var response = _mapper.Map<SIKPCalonDebiturResponseDto>(returnedSIKPCalonDebitur);

                await _SIKPCalonDebitur.SaveChangeAsync();
                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}