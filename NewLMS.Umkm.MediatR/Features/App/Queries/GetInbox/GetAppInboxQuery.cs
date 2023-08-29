using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data.Dto.AppSettingJson;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.MediatR.Features.Apps.Queries.GetInbox
{
    public class GetAppInboxQuery : PaginationRequest, IRequest<ServiceResponse<List<AppInboxResponse>>>
    {
    }

    public class GetAppInboxQueryHandler : IRequestHandler<GetAppInboxQuery, ServiceResponse<List<AppInboxResponse>>>
    {
        private readonly UserContext _userContext;
        private readonly ICurrentUserService _userInfoToken;
        public GetAppInboxQueryHandler(UserContext userContext, ICurrentUserService userInfoToken)
        {
            _userContext = userContext;
            _userInfoToken = userInfoToken;
        }

        public async Task<ServiceResponse<List<AppInboxResponse>>> Handle(GetAppInboxQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var claim = _userInfoToken;
                var eligibleRole = await _userContext.Roles.Where(r => _userInfoToken.IdFungsi.IdFungsis().Contains(r.IdFungsi)).AnyAsync();
                var dataInbox =
                   (from _loan in _userContext.Apps
                    join _debtor in _userContext.Debiturs on _loan.NomorKTP equals _debtor.NomorKTP into joinedDebtor
                    from _debtor in joinedDebtor.DefaultIfEmpty()
                    join _branch in _userContext.RfBranches on _loan.KodeCabang equals _branch.Code into joinedBranch
                    from _branch in joinedBranch.DefaultIfEmpty()
                    // join _product in _userContext.RFProducts on _loan.JenisProduk equals _product.ProductId into joinedProduct
                    // from _product in joinedProduct.DefaultIfEmpty()
                    // join _stage in _userContext.RfStages on _loan.StageId equals _stage.StageId into joinedStage
                    // from _stage in joinedStage.DefaultIfEmpty()
                    where 
                    eligibleRole
                    // && claim.Contains(_stage.Description.Replace(" ","_").ToLower())
                    // && (!_userInfoToken.IdFungsi.isAdminKredit() ? _loan.OwnerId == Guid.Parse(_userInfoToken.Id) : true)
                    select new AppInboxResponse
                    {
                        Id = _loan.Id,
                        LoanApplicationId = _loan.AplikasiId,
                        Fullname = _debtor.NamaLengkap,
                        Product = "-",
                        BranchName = _branch.Name,
                        BranchCode = _branch.Code,
                        Stage = "-",
                        EntryDate = _loan.CreatedDate,
                        NoIdentity = _debtor.NomorKTP,
                        Segment = "UMKM",
                        Url = $"{AppSettingJsonDto.HostFrontEnd}/stage/edit?id={_loan.Id}", 
                        Aging = 0
                        // _userContext.LoanApplicationStageLogs.
                        //     Where(x => x.LoanApplicationId == _loan.Id && x.StageId == _loan.StageId).
                        //     FirstOrDefault() != null 
                        // ?
                        //     Int32.Parse(Math.Abs(Math.Round((
                        //         DateTime.Now -  _userContext.LoanApplicationStageLogs.
                        //         Where(x => x.LoanApplicationId == _loan.Id && x.StageId == _loan.StageId).
                        //         OrderByDescending(x => x.CreatedDate).
                        //         Select(x => x.CreatedDate).
                        //         FirstOrDefault()).TotalDays)).ToString())
                        // : 
                        //     Int32.Parse(Math.Abs(Math.Round((DateTime.Now - _loan.CreatedDate).TotalDays)).ToString())
                    })
                    .AsQueryable().AsNoTracking();

                if (request.Page > 0 && request.Length > 0)
                {
                    dataInbox = dataInbox
                    .Skip((request.Page - 1) * request.Length)
                    .Take(request.Length);
                }

                var result =  await dataInbox.OrderBy(x => x.LoanApplicationId).ToListAsync();
                result = result.OrderBy(x => x.Aging).ToList();
            
                return ServiceResponse<List<AppInboxResponse>>.ReturnResultWith200(result);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<AppInboxResponse>>.ReturnException(ex);
            }
        }
        // private async Task<List<string>> RoleClaimCheck()
        // {
        //     var IdFungsi = _userInfoToken.IdFungsi.IdFungsis();
        //     var listPage = await _userContext.RoleClaims
        //                     .Include(x => x.Role)
        //                     .Include(x => x.Page)
        //                     .Where(x => IdFungsi.Contains(x.Role.IdFungsi))
        //                     .GroupBy(x => x.PageId)
        //                     .Select(x => x.Select(p => p.Page.Name.ToLower()).FirstOrDefault())
        //                     .ToListAsync();

        //     return listPage;
        // }
    }
}