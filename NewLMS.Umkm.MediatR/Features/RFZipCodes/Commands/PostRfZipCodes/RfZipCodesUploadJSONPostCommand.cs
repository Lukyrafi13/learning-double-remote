using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
{
    public interface IRfZipCodesUploadJSON
    {
        Task<bool> UploadJSON(IFormFile JSONFile);
    }

    public class RfZipCodeJSON
    {
        public RfZipCodeEntity[] RECORDS { get; set; }
    }

    public class RfZipCodeEntity
    {
        public string ZIP_CODE { get; set; }
        public string SEQ { get; set; }
        public string ZIP_DESC { get; set; }
        public string KELURAHAN { get; set; }
        public string KECAMATAN { get; set; }
        public string PROPINSI { get; set; }
        public string KOTA { get; set; }
        public string DATI_II { get; set; }
        public string NEGARA { get; set; }
        public string SANDIWILAYAHBI { get; set; }
        public string ACTIVE { get; set; }
        public string DATI_II_CODE { get; set; }
        public string CREATEBY { get; set; }
        public string CREATEDATE { get; set; }
        public string UPDATEBY { get; set; }
        public string UPDATEDATE { get; set; }
        public string KODE_PROVINSI { get; set; }
        public string KODE_KABUPATEN { get; set; }
        public string KODE_KECAMATAN { get; set; }
        public string KODE_KELURAHAN { get; set; }
    }

    public class RfZipCodesUploadJSON : IRfZipCodesUploadJSON
    {
        private readonly IGenericRepositoryAsync<RfZipCode> _RfZipCode;
        private readonly IMapper _mapper;

        public RfZipCodesUploadJSON(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _RfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<bool> UploadJSON(IFormFile JSONFile)
        {

            using var sr = new StreamReader(JSONFile.OpenReadStream(), Encoding.UTF8);
            string content = await sr.ReadToEndAsync();
            var zipCodeJSON = JsonConvert.DeserializeObject<RfZipCodeJSON>(content);

            var i = 0;

            var listZipCode = new List<RfZipCode>();
            var listExistingZipCode = new List<RfZipCode>();

            foreach (var zipCode in zipCodeJSON.RECORDS)
            {
                // index increment
                i++;
                var existing = true;

                var ZipCode = await _RfZipCode.GetByIdAsync(i, "id");

                if (ZipCode == null)
                {
                    existing = false;

                    ZipCode = new RfZipCode();
                }

                ZipCode.ZipCode = zipCode.ZIP_CODE;
                ZipCode.Seq = int.Parse(zipCode.SEQ);
                ZipCode.ZipDesc = zipCode.ZIP_DESC;
                ZipCode.Kelurahan = zipCode.KELURAHAN;
                ZipCode.Kecamatan = zipCode.KECAMATAN;
                ZipCode.Provinsi = zipCode.PROPINSI;
                ZipCode.Kota = zipCode.KOTA;
                ZipCode.Dati_II = zipCode.DATI_II;
                ZipCode.Dati_II_Code = zipCode.DATI_II_CODE;
                ZipCode.Negara = zipCode.NEGARA;
                ZipCode.SandiWilayahBI = zipCode.SANDIWILAYAHBI;
                ZipCode.Active = zipCode.ACTIVE == "1";
                ZipCode.KodeKabupaten = zipCode.KODE_KABUPATEN;
                ZipCode.KodeProvinsi = zipCode.KODE_PROVINSI;
                ZipCode.KodeKabKota = zipCode.KODE_KABUPATEN;
                ZipCode.KodeKecamatan = zipCode.KODE_KECAMATAN;
                ZipCode.KodeKelurahan = zipCode.KODE_KELURAHAN;

                if (existing){
                    listExistingZipCode.Add(ZipCode);
                }else{
                    listZipCode.Add(ZipCode);
                }
            }

            await _RfZipCode.UpdateRangeAsync(listExistingZipCode);
            await _RfZipCode.AddRangeAsync(listZipCode);

            return true;
        }
    }
}
