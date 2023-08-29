using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Commands
{
    public class RFJenisPermohonanDeleteCommand : RFJenisPermohonanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisPermohonanCommandHandler : IRequestHandler<RFJenisPermohonanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisPermohonan> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public DeleteRFJenisPermohonanCommandHandler(IGenericRepositoryAsync<RFJenisPermohonan> rfJenisPermohonan, IMapper mapper){
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisPermohonanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfJenisPermohonan = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");
            rfJenisPermohonan.IsDeleted = true;
            await _rfJenisPermohonan.UpdateAsync(rfJenisPermohonan);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}