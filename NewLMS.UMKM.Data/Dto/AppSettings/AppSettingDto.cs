using System;

namespace NewLMS.UMKM.Data.Dto
{
    public class AppSettingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
