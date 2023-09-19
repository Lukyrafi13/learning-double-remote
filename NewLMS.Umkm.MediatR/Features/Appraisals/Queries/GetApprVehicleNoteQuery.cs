using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalVehicle;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetApprVehicleNoteQuery : IRequest<ServiceResponse<IEnumerable<ApprVehicleNoteResponse>>>
    {
        public Guid VehicleTemplateGuid { get; set; }
    }

    public class GetApprVehicleNoteQueryHandler : IRequestHandler<GetApprVehicleNoteQuery, ServiceResponse<IEnumerable<ApprVehicleNoteResponse>>>
    {
        private IGenericRepositoryAsync<ApprVehicleNote> _ApprVehicleNote;
        private IMapper _mapper;

        public GetApprVehicleNoteQueryHandler(IGenericRepositoryAsync<ApprVehicleNote> ApprVehicleNote, IMapper mapper)
        {
            _ApprVehicleNote = ApprVehicleNote;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<ApprVehicleNoteResponse>>> Handle(GetApprVehicleNoteQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprVehicleNote.GetListByPredicate(x => x.ApprVehicleTemplateGuid == request.VehicleTemplateGuid, null);
            var dataVm = _mapper.Map<IEnumerable<ApprVehicleNoteResponse>>(data);

            return ServiceResponse<IEnumerable<ApprVehicleNoteResponse>>.ReturnResultWith200(dataVm);
        }
    }
}
