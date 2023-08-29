using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaPinjamanDariBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaPinjamanDariBanks.Commands
{
    public class AnalisaPinjamanDariBankPostCommand : AnalisaPinjamanDariBankPostRequestDto, IRequest<ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {

    }
    public class AnalisaPinjamanDariBankPostCommandHandler : IRequestHandler<AnalisaPinjamanDariBankPostCommand, ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public AnalisaPinjamanDariBankPostCommandHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper)
        {
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaPinjamanDariBankResponseDto>> Handle(AnalisaPinjamanDariBankPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var AnalisaPinjamanDariBank = _mapper.Map<AnalisaPinjamanDariBank>(request);

                var returnedAnalisaPinjamanDariBank = await _AnalisaPinjamanDariBank.AddAsync(AnalisaPinjamanDariBank, callSave: false);

                // var response = _mapper.Map<AnalisaPinjamanDariBankResponseDto>(returnedAnalisaPinjamanDariBank);
                var response = _mapper.Map<AnalisaPinjamanDariBankResponseDto>(returnedAnalisaPinjamanDariBank);

                await _AnalisaPinjamanDariBank.SaveChangeAsync();
                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}