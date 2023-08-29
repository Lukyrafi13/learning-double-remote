using System.Collections.Generic;
using System.Linq;
// using NewLMS.Umkm.Data.Dto.AppSettingJson;

namespace NewLMS.Umkm.Helper
{
    public static class LMSExtention
    {
        public static List<string> IdFungsis(this string idFungsi)
        {
            return idFungsi.Split(',').ToList();
        }
    }
}
