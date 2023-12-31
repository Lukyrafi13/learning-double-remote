﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1PostCommand : RFSectorLBU1PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRFSectorLBU1CommandHandler : IRequestHandler<RFSectorLBU1PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _RFSectorLBU1;
        private readonly IMapper _mapper;

        public PostRFSectorLBU1CommandHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _RFSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU1PostCommand request, CancellationToken cancellationToken)
        {
            var RFSectorLBU1 = _mapper.Map<RfSectorLBU1>(request);
            await _RFSectorLBU1.AddAsync(RFSectorLBU1);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
