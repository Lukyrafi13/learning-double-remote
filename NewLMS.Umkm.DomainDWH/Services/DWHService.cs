﻿using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.Data.Constants;
using NewLMS.UMKM.Domain.Dwh.Context;
using NewLMS.UMKM.Domain.Context;
using NewLMS.UMKM.DomainDWH.Dtos;

namespace NewLMS.UMKM.Domain.Dwh.Services
{
    public interface IDWHService
    {
        Task<List<GetExtAccByNoAccountResponse>> GetExtAccByNoAccount(string NoExtAcc);
    }
    public class DWHService : IDWHService
    {
        private readonly DWHContext _context;

        // private readonly UserContext _userContext;
        public DWHService(DWHContext context)
        {
            _context = context;
            // _userContext = userContext;
        }

        public async Task<List<GetExtAccByNoAccountResponse>> GetExtAccByNoAccount(string NoExtAcc)
        {
            var result = await (from extAcc in _context.DWH_EXTERNALACC
                                where
                                    extAcc.EXTERNAL_ACCOUNT == NoExtAcc
                                select new GetExtAccByNoAccountResponse
                                {
                                    BRANCHID = extAcc.BRANCHID,
                                    CIF = extAcc.CIF,
                                    SUFFIX = extAcc.SUFFIX,
                                    EXTERNAL_ACCOUNT = extAcc.EXTERNAL_ACCOUNT,
                                    FULLNAME = extAcc.FULLNAME,
                                }).ToListAsync();
            return result;
        }
    }
}
