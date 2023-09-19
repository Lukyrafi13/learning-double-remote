using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Constants
{
    public static class CommonConstant
    {
        public const string ADD = "ADD";
        public const string UPDATE = "UPDATE";
        public const string DELETE = "DELETE";
        public const string SQLLatin1GeneralCP1CSAS = "SQL_Latin1_General_CP1_CS_AS";
        public const string Digiloan = "Digiloan";

        public static T GetSettingOrDefault<T>(string tableName) where T : BaseEntity
        {
            return (T)Convert.ChangeType(tableName, typeof(T));
        }
    }


}
