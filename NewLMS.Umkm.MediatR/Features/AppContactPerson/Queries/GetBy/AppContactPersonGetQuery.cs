using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppContactPersons;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AppContactPersons.Queries
{
    public class AppContactPersonGetQuery : AppContactPersonFindRequestDto, IRequest<ServiceResponse<AppContactPersonResponseDto>>
    {
    }

    public class AppContactPersonGetQueryHandler : IRequestHandler<AppContactPersonGetQuery, ServiceResponse<AppContactPersonResponseDto>>
    {
        private IGenericRepositoryAsync<AppContactPerson> _AppContactPerson;
        private readonly IMapper _mapper;

        public AppContactPersonGetQueryHandler(IGenericRepositoryAsync<AppContactPerson> AppContactPerson, IMapper mapper)
        {
            _AppContactPerson = AppContactPerson;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AppContactPersonResponseDto>> Handle(AppContactPersonGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "App",
                    "RFRelationCol",
                    "RFGender",
                };

                var data = await _AppContactPerson.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AppContactPersonResponseDto>.Return404("Data AppContactPerson not found");
                var response = _mapper.Map<AppContactPersonResponseDto>(data);
                return ServiceResponse<AppContactPersonResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppContactPersonResponseDto>.ReturnException(ex);
            }
        }
    }
}