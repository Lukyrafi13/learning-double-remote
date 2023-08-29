using System.Collections.Generic;

namespace NewLMS.UMKM.Common.Helpers
{
    public static class CommonHelper
    {
        public static List<string> SubmissionTypes = new List<string> {
            "1",
            "2",
            "3"
        };
        public static string GetSubmissionTypeFromString(string submissionType)
        {
            var res = submissionType;

            switch (submissionType.ToLower())
            {
                case "new":
                    res = "1";
                    break;
                case "mengulang":
                    res = "2";
                    break;
                case "topup":
                case "top up":
                    res = "3";
                    break;

                default:
                    break;
            }

            return res;
        }
    }
}