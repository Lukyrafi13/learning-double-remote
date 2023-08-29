using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaVariabelTenagaKerjas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabelTenagaKerjas.Commands
{
    public class BiayaVariabelTenagaKerjaPostCommand : BiayaVariabelTenagaKerjaPostRequestDto, IRequest<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
    {

    }
    public class PostBiayaVariabelTenagaKerjaCommandHandler : IRequestHandler<BiayaVariabelTenagaKerjaPostCommand, ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<BiayaVariabelTenagaKerja> _BiayaVariabelTenagaKerja;
        private readonly IMapper _mapper;

        public PostBiayaVariabelTenagaKerjaCommandHandler(IGenericRepositoryAsync<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerja, IMapper mapper)
        {
            _BiayaVariabelTenagaKerja = BiayaVariabelTenagaKerja;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>> Handle(BiayaVariabelTenagaKerjaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var BiayaVariabelTenagaKerja = _mapper.Map<BiayaVariabelTenagaKerja>(request);

                var returnedBiayaVariabelTenagaKerja = await _BiayaVariabelTenagaKerja.AddAsync(BiayaVariabelTenagaKerja, callSave: false);

                // var response = _mapper.Map<BiayaVariabelTenagaKerjaResponseDto>(returnedBiayaVariabelTenagaKerja);
                var response = _mapper.Map<BiayaVariabelTenagaKerjaResponseDto>(returnedBiayaVariabelTenagaKerja);

                await _BiayaVariabelTenagaKerja.SaveChangeAsync();
                return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}