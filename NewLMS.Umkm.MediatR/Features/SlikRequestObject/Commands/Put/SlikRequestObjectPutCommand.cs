using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikRequestObjects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Commands
{
    public class SlikRequestObjectPutCommand : SlikRequestObjectPutRequestDto, IRequest<ServiceResponse<SlikRequestObjectResponseDto>>
    {
    }

    public class PutSlikRequestObjectCommandHandler : IRequestHandler<SlikRequestObjectPutCommand, ServiceResponse<SlikRequestObjectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IMapper _mapper;

        public PutSlikRequestObjectCommandHandler(IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject, IMapper mapper)
        {
            _SlikRequestObject = SlikRequestObject;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikRequestObjectResponseDto>> Handle(SlikRequestObjectPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSlikRequestObject = await _SlikRequestObject.GetByIdAsync(request.Id, "Id");
                
                existingSlikRequestObject.SlikRequestId = request.SlikRequestId;
                existingSlikRequestObject.SlikObjectTypeId = request.SlikObjectTypeId;
                existingSlikRequestObject.Fullname = request.Fullname;
                existingSlikRequestObject.NPWP = request.NPWP;
                existingSlikRequestObject.NoIdentity = request.NoIdentity;
                existingSlikRequestObject.DateOfBirth = request.DateOfBirth;
                existingSlikRequestObject.PlaceOfBirth = request.PlaceOfBirth;
                existingSlikRequestObject.ApplicationStatus = request.ApplicationStatus;
                existingSlikRequestObject.RequestDate = request.RequestDate;
                existingSlikRequestObject.SLIKDocumentUrl = request.SLIKDocumentUrl;
                existingSlikRequestObject.KodeRefPengguna = request.KodeRefPengguna;
                existingSlikRequestObject.TujuanPermintaan = request.TujuanPermintaan;
                existingSlikRequestObject.SLIKResult = request.SLIKResult;
                existingSlikRequestObject.RoboSlik = request.RoboSlik;

                await _SlikRequestObject.UpdateAsync(existingSlikRequestObject);

                var response = _mapper.Map<SlikRequestObjectResponseDto>(existingSlikRequestObject);

                return ServiceResponse<SlikRequestObjectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikRequestObjectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}