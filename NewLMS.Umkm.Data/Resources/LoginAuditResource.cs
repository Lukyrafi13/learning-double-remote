namespace NewLMS.Umkm.Data.Resources
{
    public class LoginAuditResource : ResourceParameter
    {
        public LoginAuditResource() : base("LoginTime")
        {
        }

        public string UserName { get; set; }
    }
}
