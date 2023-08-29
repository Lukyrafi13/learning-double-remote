using System.Collections.Generic;
using System.Linq;
// using NewLMS.UMKM.Data.Dto.AppSettingJson;

namespace NewLMS.UMKM.Helper
{
    public static class LMSExtention
    {
        public static List<string> IdFungsis(this string idFungsi)
        {
            return idFungsi.Split(',').ToList();
        }
    }
}
