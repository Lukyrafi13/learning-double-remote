using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AdditionalDealInformation
{
    public class MPOAdditionalDealInformationResponse
    {
        [JsonProperty("0")]
        public MPOAdditionalDealInformationResponseDetail MPOAdditionalDealInformationResponseDetail { get; set; }
    }
    public class MPOAdditionalDealInformationResponseDetail
    {
        [JsonProperty("BUEQF")]
        public string BUEQF { get; set; }

        [JsonProperty("BULPV")]
        public string BULPV { get; set; }

        [JsonProperty("BUIGR")]
        public string BUIGR { get; set; }

        [JsonProperty("BUBRNM")]
        public string BUBRNM { get; set; }

        [JsonProperty("BUDLP")]
        public string BUDLP { get; set; }

        [JsonProperty("BUDLR")]
        public string BUDLR { get; set; }

        [JsonProperty("BUPSQ")]
        public string BUPSQ { get; set; }

        [JsonProperty("BUPOD")]
        public string BUPOD { get; set; }

        [JsonProperty("BUD001")]
        public string BUD001 { get; set; }

        [JsonProperty("BUD002")]
        public string BUD002 { get; set; }

        [JsonProperty("BUD003")]
        public string BUD003 { get; set; }

        [JsonProperty("BUD005")]
        public string BUD005 { get; set; }

        [JsonProperty("BUD006")]
        public string BUD006 { get; set; }

        [JsonProperty("BUD008")]
        public string BUD008 { get; set; }

        [JsonProperty("BUD009")]
        public string BUD009 { get; set; }

        [JsonProperty("BUD011")]
        public string BUD011 { get; set; }

        [JsonProperty("BUD012")]
        public string BUD012 { get; set; }

        [JsonProperty("BUD013")]
        public string BUD013 { get; set; }

        [JsonProperty("BUD014")]
        public string BUD014 { get; set; }

        [JsonProperty("BUD015")]
        public string BUD015 { get; set; }

        [JsonProperty("BUD004")]
        public string BUD004 { get; set; }

        [JsonProperty("BUD016")]
        public string BUD016 { get; set; }

        [JsonProperty("BUD018")]
        public string BUD018 { get; set; }

        [JsonProperty("BUD019")]
        public string BUD019 { get; set; }

        [JsonProperty("BUD021")]
        public string BUD021 { get; set; }

        [JsonProperty("BUD023")]
        public string BUD023 { get; set; }

        [JsonProperty("BUSL02")]
        public string BUSL02 { get; set; }

        [JsonProperty("BUSL05")]
        public string BUSL05 { get; set; }

        [JsonProperty("BUSL06")]
        public string BUSL06 { get; set; }

        [JsonProperty("BUMARD")]
        public string BUMARD { get; set; }

        [JsonProperty("BUMARG")]
        public string BUMARG { get; set; }

        [JsonProperty("BUD024")]
        public string BUD024 { get; set; }

        [JsonProperty("BUD025")]
        public string BUD025 { get; set; }

        [JsonProperty("BUD026")]
        public string BUD026 { get; set; }

        [JsonProperty("BUD046")]
        public string BUD046 { get; set; }

        [JsonProperty("BUD027")]
        public string BUD027 { get; set; }

        [JsonProperty("BUD035")]
        public string BUD035 { get; set; }

        [JsonProperty("BUD047")]
        public string BUD047 { get; set; }

        [JsonProperty("BUD048")]
        public string BUD048 { get; set; }

        [JsonProperty("BUD049")]
        public string BUD049 { get; set; }

        [JsonProperty("BUD052")]
        public string BUD052 { get; set; }

        [JsonProperty("BUD053")]
        public string BUD053 { get; set; }

        [JsonProperty("BUD054")]
        public string BUD054 { get; set; }

        [JsonProperty("BUD081")]
        public string BUD081 { get; set; }

        [JsonProperty("BUD084")]
        public string BUD084 { get; set; }

        [JsonProperty("BUD088")]
        public string BUD088 { get; set; }
    }


}
