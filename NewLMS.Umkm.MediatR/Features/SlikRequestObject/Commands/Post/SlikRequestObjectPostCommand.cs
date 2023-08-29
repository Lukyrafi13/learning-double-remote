using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikRequestObjects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SlikRequestObjects.Commands
{
    public class SlikRequestObjectPostCommand : SlikRequestObjectPostRequestDto, IRequest<ServiceResponse<SlikRequestObjectResponseDto>>
    {

    }
    public class SlikRequestObjectPostCommandHandler : IRequestHandler<SlikRequestObjectPostCommand, ServiceResponse<SlikRequestObjectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IMapper _mapper;

        public SlikRequestObjectPostCommandHandler(IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject, IMapper mapper)
        {
            _SlikRequestObject = SlikRequestObject;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikRequestObjectResponseDto>> Handle(SlikRequestObjectPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SlikRequestObject = _mapper.Map<SlikRequestObject>(request);

                var returnedSlikRequestObject = await _SlikRequestObject.AddAsync(SlikRequestObject, callSave: false);

                // var response = _mapper.Map<SlikRequestObjectResponseDto>(returnedSlikRequestObject);
                var response = _mapper.Map<SlikRequestObjectResponseDto>(returnedSlikRequestObject);

                await _SlikRequestObject.SaveChangeAsync();
                return ServiceResponse<SlikRequestObjectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikRequestObjectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}