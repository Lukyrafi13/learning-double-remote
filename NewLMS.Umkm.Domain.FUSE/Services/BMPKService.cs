using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Domain.FUSE.Context;
using NewLMS.Umkm.Domain.FUSE.Entites;
using NewLMS.Umkm.Domain.FUSE.GenericRepositoryFuse;
using NewLMS.Umkm.Domain.FUSE.Models;

namespace NewLMS.Umkm.Domain.FUSE.Services
{
    public interface IBMPKService
    {
        // Task<List<BMPKModel>> GetBMPK();
        Task<List<BMPKModel>> GetBMPK();
        Task<List<BMPKModel>> GetBMPKByFilter(RequestParameter request);
        Task<BMPKModel> GetBMPKByGuid(int BMPKId);
        Task<bool> AddBMPK(BMPK data);
        Task<bool> DeleteBMPK(int BMPKId);
        Task<bool> UpdateBMPK(int BMPKId, BMPKModel model);

    }
    public class BMPKService : IBMPKService
    {
        private readonly IGenericRepositoryFuseAsync<BMPK> _fuseContext;
        private object _BMPKService;
        private BMPK data;

        public BMPKService(IGenericRepositoryFuseAsync<BMPK> fuseContext)
        {
            _fuseContext = fuseContext;
        }

        public async Task<bool> AddBMPK(BMPK data)
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

        public async Task<bool> DeleteBMPK(int BMPKId)
        {
            try
            {

                var data = await _fuseContext.GetByIdAsync(BMPKId, "BMPKId");
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
        public async Task<bool> UpdateBMPK(int BMPKId, BMPKModel request)
        {
            try
            {

                var data = await _fuseContext.GetByIdAsync(BMPKId, "BMPKId");
                data.Periode = request.Periode;
                data.ModalInti = request.ModalInti;
                data.ModalPelengkap = request.ModalPelengkap;
                data.PctGroup = request.PctGroup;
                data.PctInfrastruktur = request.PctInfrastruktur;
                data.PctPihakTerkait = request.PctPihakTerkait;
                data.PctTidakTerkait = request.PctTidakTerkait;
                data.PctMaxPortofolio = request.PctMaxPortofolio;
                data.IsDeleted = request.IsDeleted;

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
        // public BMPKService(FUSEContext fuseContext)
        // {
        //     _fuseContext = fuseContext;
        // }

        public async Task<List<BMPKModel>> GetBMPK()
        {
            try
            {
                var BMPK = await _fuseContext.GetAllAsync();
                var BMPKModelList = new List<BMPKModel>();

                foreach (var data in BMPK)
                {
                    BMPKModelList.Add(new BMPKModel
                    {
                        BMPKId = data.BMPKId,
                        Periode = data.Periode,
                        ModalInti = data.ModalInti,
                        ModalPelengkap = data.ModalPelengkap,
                        PctGroup = data.PctGroup,
                        PctInfrastruktur = data.PctInfrastruktur,
                        PctPihakTerkait = data.PctPihakTerkait,
                        PctTidakTerkait = data.PctTidakTerkait,
                        PctMaxPortofolio = data.PctMaxPortofolio,
                        IsDeleted = data.IsDeleted,
                    });
                }

                // var data = await query.ToListAsync();
                return BMPKModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BMPKModel>> GetBMPKByFilter(RequestParameter request)
        {
            try
            {
                var BMPK = await _fuseContext.GetPagedReponseAsync(request);
                var BMPKModelList = new List<BMPKModel>();

                foreach (var data in BMPK.Results)
                {
                    BMPKModelList.Add(new BMPKModel
                    {
                        BMPKId = data.BMPKId,
                        Periode = data.Periode,
                        ModalInti = data.ModalInti,
                        ModalPelengkap = data.ModalPelengkap,
                        PctGroup = data.PctGroup,
                        PctInfrastruktur = data.PctInfrastruktur,
                        PctPihakTerkait = data.PctPihakTerkait,
                        PctTidakTerkait = data.PctTidakTerkait,
                        PctMaxPortofolio = data.PctMaxPortofolio,
                        IsDeleted = data.IsDeleted,
                    });
                }

                // var data = await query.ToListAsync();
                return BMPKModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<BMPKModel> GetBMPKByGuid(int BMPKId)
        {
            try
            {
                var data = await _fuseContext.GetListByPredicate(x => x.BMPKId == BMPKId && x.IsDeleted == false);

                // var data = await query.ToListAsync();
                var model = new BMPKModel
                {
                    BMPKId = BMPKId,
                    Periode = data?.FirstOrDefault()?.Periode,
                    ModalInti = data?.FirstOrDefault()?.ModalInti,
                    ModalPelengkap = data?.FirstOrDefault()?.ModalPelengkap,
                    PctGroup = data?.FirstOrDefault()?.PctGroup,
                    PctInfrastruktur = data?.FirstOrDefault()?.PctInfrastruktur,
                    PctPihakTerkait = data?.FirstOrDefault()?.PctPihakTerkait,
                    PctTidakTerkait = data?.FirstOrDefault()?.PctTidakTerkait,
                    PctMaxPortofolio = data?.FirstOrDefault()?.PctMaxPortofolio,
                    IsDeleted = (data?.FirstOrDefault()?.IsDeleted) != null,
                };
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        // public async Task<List<BMPKModel>> GetBMPK()
        // {
        //     try {
        //         var query = (
        //             from data in _fuseContext.BMPK
        //             select new BMPKModel
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