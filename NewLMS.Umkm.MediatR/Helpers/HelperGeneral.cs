using NewLMS.Umkm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Helpers
{
    public class HelperGeneral
    {
        public static TInput1 UpdateBaseEntityTime<TInput1, TInput2>(TInput1 tagetEntity, TInput2 sourceEntity)
        where TInput1 : BaseEntity where TInput2 : BaseEntity
        {

            tagetEntity.CreatedDate = sourceEntity.CreatedDate.Subtract(TimeSpan.FromHours(7));
            tagetEntity.CreatedBy = sourceEntity.CreatedBy;
            tagetEntity.DeletedDate = sourceEntity.DeletedDate?.Subtract(TimeSpan.FromHours(7));
            tagetEntity.DeletedBy = sourceEntity.DeletedBy;
            tagetEntity.IsDeleted = sourceEntity.IsDeleted;

            return tagetEntity;
        }

        public static int? CalculateAge(DateTime? dateOfBirth)
        {
            if (dateOfBirth == null)
                return null;

            DateTime tanggalSekarang = DateTime.Today;
            int umur = tanggalSekarang.Year - dateOfBirth.Value.Year;

            // Memeriksa apakah sudah ulang tahun atau belum
            if (tanggalSekarang < dateOfBirth.Value.AddYears(umur))
            {
                umur--;
            }

            return umur;
        }

    }
}
