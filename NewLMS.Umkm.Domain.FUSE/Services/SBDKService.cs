using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Domain.FUSE.Context;
using NewLMS.UMKM.Domain.FUSE.Entites;
using NewLMS.UMKM.Domain.FUSE.GenericRepositoryFuse;
using NewLMS.UMKM.Domain.FUSE.Models;

namespace NewLMS.UMKM.Domain.FUSE.Services
{
    public interface ISBDKService
    {
        // Task<List<SBDKModel>> GetSBDK();
        Task<List<SBDKModel>> GetSBDK();
        Task<List<SBDKModel>> GetSBDKByFilter(RequestParameter request);
        Task<SBDKModel> GetSBDKByGuid(Guid SBDKGuid);
        Task<bool> AddSBDK(SBDK data);
        Task<bool> DeleteSBDK(Guid SBDKGuid);
        Task<bool> UpdateSBDK(Guid SBDKGuid, SBDKModel model);

    }
    public class SBDKService : ISBDKService
    {
        private readonly IGenericRepositoryFuseAsync<SBDK> _fuseContext;
        private object _sbdkService;
        private SBDK data;

        public SBDKService(IGenericRepositoryFuseAsync<SBDK> fuseContext)
        {
            _fuseContext = fuseContext;
        }

        public async Task<bool> AddSBDK(SBDK data)
        {
            try
            {
                await _fuseContext.AddAsync(data);


                // var data = await query.ToListAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSBDK(Guid SBDKGuid)
        {
            try
            {

                var data = await _fuseContext.GetByIdAsync(SBDKGuid, "SBDKGuid");
                data.IsDeleted = true;
                await _fuseContext.UpdateAsync(data);


                // var data = await query.ToListAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateSBDK(Guid SBDKGuid, SBDKModel request)
        {
            try
            {

                var data = await _fuseContext.GetByIdAsync(SBDKGuid, "SBDKGuid");
                data.Period = DateTime.Now;
                data.HPDKKorporasi = request.HPDKKorporasi;
                data.HPDKRitel = request.HPDKRitel;
                data.HPDKMikro = request.HPDKMikro;
                data.HPDKKPR = request.HPDKKPR;
                data.HPDKNonKPR = request.HPDKNonKPR;
                data.OverHeadKorporasi = request.OverHeadKorporasi;
                data.OverHeadRitel = request.OverHeadRitel;
                data.OverHeadMikro = request.OverHeadMikro;
                data.OverHeadKPR = request.OverHeadKPR;
                data.OverHeadNonKPR = request.OverHeadNonKPR;
                data.MarjinKorporasi = request.MarjinKorporasi;
                data.MarjinRitel = request.MarjinRitel;
                data.MarjinMikro = request.MarjinMikro;
                data.MarjinKPR = request.MarjinKPR;
                data.MarjinNonKPR = request.MarjinNonKPR;

                await _fuseContext.UpdateAsync(data);


                // var data = await query.ToListAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // private readonly FUSEContext _fuseContext;
        // public SBDKService(FUSEContext fuseContext)
        // {
        //     _fuseContext = fuseContext;
        // }

        public async Task<List<SBDKModel>> GetSBDK()
        {
            try
            {
                var sbdk = await _fuseContext.GetAllAsync();
                var sbdkModelList = new List<SBDKModel>();

                foreach (var data in sbdk)
                {
                    sbdkModelList.Add(new SBDKModel
                    {
                        Period = data.Period,
                        HPDKKorporasi = data.HPDKKorporasi,
                        HPDKRitel = data.HPDKRitel,
                        HPDKMikro = data.HPDKMikro,
                        HPDKKPR = data.HPDKKPR,
                        HPDKNonKPR = data.HPDKNonKPR,
                        OverHeadKorporasi = data.OverHeadKorporasi,
                        OverHeadRitel = data.OverHeadRitel,
                        OverHeadMikro = data.OverHeadMikro,
                        OverHeadKPR = data.OverHeadKPR,
                        OverHeadNonKPR = data.OverHeadNonKPR,
                        MarjinKorporasi = data.MarjinKorporasi,
                        MarjinRitel = data.MarjinRitel,
                        MarjinMikro = data.MarjinMikro,
                        MarjinKPR = data.MarjinKPR,
                        MarjinNonKPR = data.MarjinNonKPR
                    });
                }

                // var data = await query.ToListAsync();
                return sbdkModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<SBDKModel>> GetSBDKByFilter(RequestParameter request)
        {
            try
            {
                var sbdk = await _fuseContext.GetPagedReponseAsync(request);
                var sbdkModelList = new List<SBDKModel>();

                foreach (var data in sbdk.Results)
                {
                    sbdkModelList.Add(new SBDKModel
                    {
                        Period = data.Period,
                        HPDKKorporasi = data.HPDKKorporasi,
                        HPDKRitel = data.HPDKRitel,
                        HPDKMikro = data.HPDKMikro,
                        HPDKKPR = data.HPDKKPR,
                        HPDKNonKPR = data.HPDKNonKPR,
                        OverHeadKorporasi = data.OverHeadKorporasi,
                        OverHeadRitel = data.OverHeadRitel,
                        OverHeadMikro = data.OverHeadMikro,
                        OverHeadKPR = data.OverHeadKPR,
                        OverHeadNonKPR = data.OverHeadNonKPR,
                        MarjinKorporasi = data.MarjinKorporasi,
                        MarjinRitel = data.MarjinRitel,
                        MarjinMikro = data.MarjinMikro,
                        MarjinKPR = data.MarjinKPR,
                        MarjinNonKPR = data.MarjinNonKPR
                    });
                }

                // var data = await query.ToListAsync();
                return sbdkModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<SBDKModel> GetSBDKByGuid(Guid SBDKGuid)
        {
            try
            {
                var data = await _fuseContext.GetListByPredicate(x => x.SBDKGuid == SBDKGuid && x.IsDeleted == false);

                // var data = await query.ToListAsync();
                var model = new SBDKModel
                {
                    SBDKGuid = SBDKGuid,
                    Period = data?.FirstOrDefault()?.Period,
                    HPDKKorporasi = data?.FirstOrDefault()?.HPDKKorporasi,
                    HPDKRitel = data?.FirstOrDefault()?.HPDKRitel,
                    HPDKMikro = data?.FirstOrDefault()?.HPDKMikro,
                    HPDKKPR = data?.FirstOrDefault()?.HPDKKPR,
                    HPDKNonKPR = data?.FirstOrDefault()?.HPDKNonKPR,
                    OverHeadKorporasi = data?.FirstOrDefault()?.OverHeadKorporasi,
                    OverHeadRitel = data?.FirstOrDefault()?.OverHeadRitel,
                    OverHeadMikro = data?.FirstOrDefault()?.OverHeadMikro,
                    OverHeadKPR = data?.FirstOrDefault()?.OverHeadKPR,
                    OverHeadNonKPR = data?.FirstOrDefault()?.OverHeadNonKPR,
                    MarjinKorporasi = data?.FirstOrDefault()?.MarjinKorporasi,
                    MarjinRitel = data?.FirstOrDefault()?.MarjinRitel,
                    MarjinMikro = data?.FirstOrDefault()?.MarjinMikro,
                    MarjinKPR = data?.FirstOrDefault()?.MarjinKPR,
                    MarjinNonKPR = data?.FirstOrDefault()?.MarjinNonKPR,
                    IsDeleted = data?.FirstOrDefault()?.IsDeleted == null ? false : true
                };
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        // public async Task<List<SBDKModel>> GetSBDK()
        // {
        //     try {
        //         var query = (
        //             from data in _fuseContext.SBDK
        //             select new SBDKModel
        //             {
        //                 Period = data.Period,
        //                 HPDK = data.HPDK,
        //                 OverHeadKorporasi = data.OverHeadKorporasi,
        //                 OverHeadRitel = data.OverHeadRitel,
        //                 OverHeadMikro = data.OverHeadMikro,
        //                 OverHeadKPR = data.OverHeadKPR,
        //                 OverHeadNonKPR = data.OverHeadNonKPR,
        //                 MarjinKorporasi = data.MarjinKorporasi,
        //                 MarjinRitel = data.MarjinRitel,
        //                 MarjinMikro = data.MarjinMikro,
        //                 MarjinKPR = data.MarjinKPR,
        //                 MarjinNonKPR = data.MarjinNonKPR
        //             }
        //         ).AsQueryable();

        //         var data = await query.ToListAsync();
        //         return data;
        //     } catch(Exception ex) {
        //         throw new Exception(ex.Message);
        //     }
        // }
    }
}