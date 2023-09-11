using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Users
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePhoto { get; set; }
        public string Provider { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public string Nama { get; set; }
        public string Nip { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        public string KodeInduk { get; set; }
        public string NamaInduk { get; set; }
        public string KodeKanwil { get; set; }
        public string NamaKanwil { get; set; }
        public string Jabatan { get; set; }
        public string KodePenempatan { get; set; }
        public string PosisiPenempatan { get; set; }
        public string KodeGrade { get; set; }
        public string IdFungsi { get; set; }
        public string FungsiTambahan { get; set; }
        public string LimitDebet { get; set; }
        public string LimitKredit { get; set; }
        public string UimId { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public bool IsUseUim { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
    }

    public class UserSimpleResponse
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePhoto { get; set; }
        public string Provider { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public string Nama { get; set; }
        public string Nip { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        public string KodeInduk { get; set; }
        public string NamaInduk { get; set; }
        public string KodeKanwil { get; set; }
        public string NamaKanwil { get; set; }
        public string Jabatan { get; set; }
        public string KodePenempatan { get; set; }
        public string PosisiPenempatan { get; set; }
        public string KodeGrade { get; set; }
        public string IdFungsi { get; set; }
        public string FungsiTambahan { get; set; }
        public string LimitDebet { get; set; }
        public string LimitKredit { get; set; }
        public string UimId { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public bool IsUseUim { get; set; } = true;
    }
}
