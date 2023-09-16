using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.AppraisalWorkPapers.Queries
{
    public class GetMLiquidationOptionQuery : IRequest<ServiceResponse<List<SimpleResponseWithScore<string>>>>
    {
        public string ItemId;
    }

    public class GetMLiquidationOptionQueryHandler : IRequestHandler<GetMLiquidationOptionQuery, ServiceResponse<List<SimpleResponseWithScore<string>>>>
    {
        private readonly IGenericRepositoryAsync<MLiquidationOption> _mLiquidationOption;
        private readonly IMapper _mapper;

        public GetMLiquidationOptionQueryHandler(
            IMapper mapper,
            IGenericRepositoryAsync<MLiquidationOption> mLiquidationOption)
        {
            _mapper = mapper;
            _mLiquidationOption = mLiquidationOption;
        }
        public async Task<ServiceResponse<List<SimpleResponseWithScore<string>>>> Handle(GetMLiquidationOptionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var mOptions = await _mLiquidationOption.GetListByPredicate(x => x.ItemId == request.ItemId);
                var dataVm = _mapper.Map<List<SimpleResponseWithScore<string>>>(mOptions);

                return ServiceResponse<List<SimpleResponseWithScore<string>>>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponseWithScore<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
