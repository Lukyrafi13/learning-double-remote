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
    public class AnalisaPinjamanDariBankPutCommand : AnalisaPinjamanDariBankPutRequestDto, IRequest<ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {
    }

    public class PutAnalisaPinjamanDariBankCommandHandler : IRequestHandler<AnalisaPinjamanDariBankPutCommand, ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public PutAnalisaPinjamanDariBankCommandHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper)
        {
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaPinjamanDariBankResponseDto>> Handle(AnalisaPinjamanDariBankPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAnalisaPinjamanDariBank = await _AnalisaPinjamanDariBank.GetByIdAsync(request.Id, "Id");
                
                existingAnalisaPinjamanDariBank = _mapper.Map<AnalisaPinjamanDariBankPutRequestDto, AnalisaPinjamanDariBank>(request, existingAnalisaPinjamanDariBank);

                await _AnalisaPinjamanDariBank.UpdateAsync(existingAnalisaPinjamanDariBank);

                var response = _mapper.Map<AnalisaPinjamanDariBankResponseDto>(existingAnalisaPinjamanDariBank);

                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}