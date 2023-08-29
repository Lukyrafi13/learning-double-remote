using Bjb.DigitalBisnis.CoreBanking.Models.AccountBasicDetailEnquiry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AdditionalInformationEnquiry
{
    public class MPOAdditionalInformationEnquiry
    {
        [JsonProperty("0")]
        public MPOAdditionalInformationEnquiryDetail mPOAdditionalInformationEnquiryDetail { get; set; }
    }

    public class MPOAdditionalInformationEnquiryDetail
    {
        [JsonProperty("BGEQF")]
        public string BGEQF { get; set; }

        [JsonProperty("BGLPV")]
        public string BGLPV { get; set; }

        [JsonProperty("BGIGR")]
        public string BGIGR { get; set; }

        [JsonProperty("BGCUS")]
        public string BGCUS { get; set; }

        [JsonProperty("BGPSQ")]
        public string BGPSQ { get; set; }

        [JsonProperty("BGPOD")]
        public string BGPOD { get; set; }

        [JsonProperty("BG0001")]
        public string BG0001 { get; set; }

        [JsonProperty("BG0003")]
        public string BG0003 { get; set; }

        [JsonProperty("BG0004")]
        public string BG0004 { get; set; }

        [JsonProperty("BG0005")]
        public string BG0005 { get; set; }

        [JsonProperty("BG0006")]
        public string BG0006 { get; set; }

        [JsonProperty("BG0007")]
        public string BG0007 { get; set; }

        [JsonProperty("BG0008")]
        public string BG0008 { get; set; }

        [JsonProperty("BG0009")]
        public string BG0009 { get; set; }

        [JsonProperty("BG0010")]
        public string BG0010 { get; set; }

        [JsonProperty("BG0011")]
        public string BG0011 { get; set; }

        [JsonProperty("BG0014")]
        public string BG0014 { get; set; }

        [JsonProperty("BG0015")]
        public string BG0015 { get; set; }

        [JsonProperty("BG0016")]
        public string BG0016 { get; set; }

        [JsonProperty("BG0021")]
        public string BG0021 { get; set; }

        [JsonProperty("BG0023")]
        public string BG0023 { get; set; }

        [JsonProperty("BG0070")]
        public string BG0070 { get; set; }

        [JsonProperty("BG0071")]
        public string BG0071 { get; set; }

        [JsonProperty("BG0073")]
        public string BG0073 { get; set; }

        [JsonProperty("BG0074")]
        public string BG0074 { get; set; }

        [JsonProperty("BG0075")]
        public string BG0075 { get; set; }

        [JsonProperty("BG0076")]
        public string BG0076 { get; set; }

        [JsonProperty("BG0078")]
        public string BG0078 { get; set; }

        [JsonProperty("BG0099")]
        public string BG0099 { get; set; }

        [JsonProperty("BG0100")]
        public string BG0100 { get; set; }

        [JsonProperty("BG018B")]
        public string BG018B { get; set; }

        [JsonProperty("BG018D")]
        public string BG018D { get; set; }

        [JsonProperty("BG019A")]
        public string BG019A { get; set; }

        [JsonProperty("BG0190")]
        public string BG0190 { get; set; }

        [JsonProperty("BG0192")]
        public string BG0192 { get; set; }

        [JsonProperty("BG0193")]
        public string BG0193 { get; set; }

        [JsonProperty("BG0197")]
        public string BG0197 { get; set; }

        [JsonProperty("BG0199")]
        public string BG0199 { get; set; }

        [JsonProperty("BG0200")]
        public string BG0200 { get; set; }

        [JsonProperty("BG0201")]
        public string BG0201 { get; set; }

        [JsonProperty("BG0202")]
        public string BG0202 { get; set; }

        [JsonProperty("BG0203")]
        public string BG0203 { get; set; }

        [JsonProperty("BG0204")]
        public string BG0204 { get; set; }

        [JsonProperty("BG0212")]
        public string BG0212 { get; set; }

        [JsonProperty("BG0220")]
        public string BG0220 { get; set; }
    }
}
