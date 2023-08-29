using System;
using System.Collections.Generic;
using System.Text;

namespace Bjb.DigitalBisnis.CoreBanking.Models
{
    public class CoreBankingOptionModel
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int Key { get; set; }
        public string ChannelId { get; set; }
        public string UserId { get; set; }
        public string UserPass { get; set; }
        public string RemoteIp { get; set; }

    }
}
