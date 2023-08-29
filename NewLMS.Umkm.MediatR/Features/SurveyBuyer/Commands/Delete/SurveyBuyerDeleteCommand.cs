using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveyBuyers.Commands
{
    public class SurveyBuyerDeleteCommand : SurveyBuyerFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSurveyBuyerCommandHandler : IRequestHandler<SurveyBuyerDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SurveyBuyer> _SurveyBuyer;
        private readonly IMapper _mapper;

        public DeleteSurveyBuyerCommandHandler(IGenericRepositoryAsync<SurveyBuyer> SurveyBuyer, IMapper mapper){
            _SurveyBuyer = SurveyBuyer;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SurveyBuyerDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SurveyBuyer.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SurveyBuyer.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}