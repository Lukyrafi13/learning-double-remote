using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaSandiOJKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSandiOJKs.Commands
{
    public class AnalisaSandiOJKPostCommand : AnalisaSandiOJKPostRequestDto, IRequest<ServiceResponse<AnalisaSandiOJKResponseDto>>
    {

    }
    public class AnalisaSandiOJKPostCommandHandler : IRequestHandler<AnalisaSandiOJKPostCommand, ServiceResponse<AnalisaSandiOJKResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
        private readonly IMapper _mapper;

        public AnalisaSandiOJKPostCommandHandler(IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK, IMapper mapper)
        {
            _AnalisaSandiOJK = AnalisaSandiOJK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaSandiOJKResponseDto>> Handle(AnalisaSandiOJKPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var AnalisaSandiOJK = _mapper.Map<AnalisaSandiOJK>(request);

                var returnedAnalisaSandiOJK = await _AnalisaSandiOJK.AddAsync(AnalisaSandiOJK, callSave: false);

                // var response = _mapper.Map<AnalisaSandiOJKResponseDto>(returnedAnalisaSandiOJK);
                var response = _mapper.Map<AnalisaSandiOJKResponseDto>(returnedAnalisaSandiOJK);

                await _AnalisaSandiOJK.SaveChangeAsync();
                return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}