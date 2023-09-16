using NewLMS.UMKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Helpers
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
    }
}
