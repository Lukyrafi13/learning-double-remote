using System;
using System.Collections.Generic;
using System.Globalization;

namespace NewLMS.UMKM.Helper
{
    public static class DocumentHelper
    {
        public static int val = 0;

        static readonly CultureInfo culture  = new CultureInfo("id-ID");

        public static string getFileName(string url)
        {
            url = url.Replace(@"\", @"/").Replace(@"\\", @"/");
            int pos = url.LastIndexOf("/") + 1;
            return url.Substring(pos, url.Length - pos);
        }

        public static string GetSisaGaji(int SourceOfPayment, int MonthlyInstallment)
        {
            var hasil = SourceOfPayment > 0 ? SourceOfPayment - MonthlyInstallment : 0;
            return hasil.ToString("c", culture).Replace("Rp", "");
        }

        public static string calcNilaiPertanggungan(int plafon, float interestTotal)
        {
            var values = plafon + (plafon * (interestTotal / 100)) / 12;
            return values.ToString("c", culture).Replace("Rp", "");
        }

        public static string MaskedLoanId(this string loanId)
        {
            if(loanId.Length < 13)
                return loanId;
            
            return loanId.Substring(0, 4) + "-" +
                   loanId.Substring(4, 3) + "-" +
                   loanId.Substring(7, 6) + "-" +
                   loanId.Substring(13);
        }

        public static string MaskedNPWP(this string npwp)
        {
            return npwp.Substring(0, 2) + "." +
                   npwp.Substring(3, 3) + "." +
                   npwp.Substring(5, 3) + "." +
                   npwp.Substring(8, 1) + "-" +
                   npwp.Substring(9, 3) + "." +
                   npwp.Substring(12);
        }

        public static string getAgeDebtorSpecific(this DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} Tahun{1}, {2} Bulan{3} dan {4} Hari{5}",
                                 years, (years == 1) ? "" : "",
                                 months, (months == 1) ? "" : "",
                                 days, (days == 1) ? "" : "");
        }

        public static string getAgeDebtor(this DateTime dob)
        {
            DateTime today = DateTime.Today;

            int years = today.Year - dob.Year;
            
            return years.ToString();
        }

        public static int yearDiff(this DateTime existingdate)
        {
            DateTime today = DateTime.Today;
            TimeSpan diff = today.Subtract(existingdate);
            int diffyear = diff.Days / 365; 
            return diffyear;
        }

        public static string getStatusApplikasi(string status)
        {
            return status == "1" ? "Baru" : status == "2" ? "Mengulang" : status == "3" ? "TopUp" : "-";
        }

        public static string getTotalExisting(string status)
        {
            int total = status == "1" ? 0 : status == "2" ? 0 : status == "2" ? 0 : 0;
            return total.ToString("c", culture).Replace("Rp", "");
        }

        public static string getRemainingWorkingTime(DateTime stipulation, DateTime retirement)
        {
            int years = retirement.Year - stipulation.Year;
            return years.ToString();
        }

        public static string GetSisaMasaKerja(DateTime retirement)
        {
            DateTime today = DateTime.Today;

            if (today >= retirement)
            {
                return "0 Tahun, 0 Bulan, dan 0 Hari";
            }

            int months = retirement.Month - today.Month;
            int years = retirement.Year -  today.Year;

            if (retirement.Day < today.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (retirement - today.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} Tahun{1}, {2} Bulan{3} dan {4} Hari{5}",
                                 years, (years == 1) ? "" : "",
                                 months, (months == 1) ? "" : "",
                                 days, (days == 1) ? "" : "");
        }

        public static string GetLamaBekerja(DateTime stipulation)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - stipulation.Month;
            int years = today.Year - stipulation.Year;

            if (today.Day < stipulation.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - stipulation.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} Tahun{1}, {2} Bulan{3} dan {4} Hari{5}",
                                 years, (years == 1) ? "" : "",
                                 months, (months == 1) ? "" : "",
                                 days, (days == 1) ? "" : "");
        }

        // public static string GenerateCode(string subProduct = null, string prefixcode = "KON", string kc = null)
        // {
        //     DateTime today = DateTime.Today;
        //     var romanMonth = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
        //     return $"{"/"}{kc}{"/"}{prefixcode}{"/"}{subProduct}{"/"}{romanMonth[today.Month - 1]}{"/"}{today.Year}";
        // }

        public static string GenerateCode(string subProduct = null, string prefixcode = "KON-PK", bool bulan = true)
        {
            DateTime today = DateTime.Today;
            var romanMonth = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            if (bulan == true)
            {
                return $"{"/"}{prefixcode}{"/"}{subProduct}{"/"}{romanMonth[today.Month - 1]}{"/"}{today.Year}";
            }else{
                return $"{"/"}{prefixcode}{"/"}{subProduct}{"/"}{today.Year}";
            }
        }

        public static string MaskedRupiah(this double val)
        {
            return val.ToString("c", culture).Replace("Rp", "Rp. ");
        }
        
        public static string MaskedRupiah(this int val)
        {
            return val.ToString("c", culture).Replace("Rp", "Rp. ");
        }

        public static string MaskedIDR(this double val)
        {
            return val.ToString("c", culture).Replace("Rp", "");
        }

        public static string MaskedIDR(this int val)
        {
            return val.ToString("c", culture).Replace("Rp", "");
        }

        public static string MaskedIDR(this long val)
        {
            return val.ToString("c", culture).Replace("Rp", "");
        }

      

        public static string MaskedRupiah(this long val)
        {
            return val.ToString("c", culture).Replace("Rp", "Rp. ");
        }

        public static string ConvertTgl(this DateTime date)
        {
            return date.ToString("dd MMM yyyy") ?? "-";
        }

        public static string AmountInWords(this int x)
        {
            string[] number = { "", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas" };
            string temp = "";

            if (x < 12)
            {
                temp = " " + number[x];
            }
            else if (x < 20)
            {
                temp = AmountInWords(x - 10).ToString() + " Belas";
            }
            else if (x < 100)
            {
                temp = AmountInWords(x / 10) + " Puluh" + AmountInWords(x % 10);
            }
            else if (x < 200)
            {
                temp = " Seratus" + AmountInWords(x - 100);
            }
            else if (x < 1000)
            {
                temp = AmountInWords(x / 100) + " Ratus" + AmountInWords(x % 100);
            }
            else if (x < 2000)
            {
                temp = " Seribu" + AmountInWords(x - 1000);
            }
            else if (x < 1000000)
            {
                temp = AmountInWords(x / 1000) + " Ribu" + AmountInWords(x % 1000);
            }
            else if (x < 1000000000)
            {
                temp = AmountInWords(x / 1000000) + " Juta" + AmountInWords(x % 1000000);
            }
            return temp;
        }

        public static string AmountInWords(this long x)
        {
            string[] number = { "", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas" };
            string temp = "";

            if (x < 12)
            {
                temp = " " + number[x];
            }
            else if (x < 20)
            {
                temp = AmountInWords(x - 10).ToString() + " Belas";
            }
            else if (x < 100)
            {
                temp = AmountInWords(x / 10) + " Puluh" + AmountInWords(x % 10);
            }
            else if (x < 200)
            {
                temp = " Seratus" + AmountInWords(x - 100);
            }
            else if (x < 1000)
            {
                temp = AmountInWords(x / 100) + " Ratus" + AmountInWords(x % 100);
            }
            else if (x < 2000)
            {
                temp = " Seribu" + AmountInWords(x - 1000);
            }
            else if (x < 1000000)
            {
                temp = AmountInWords(x / 1000) + " Ribu" + AmountInWords(x % 1000);
            }
            else if (x < 1000000000)
            {
                temp = AmountInWords(x / 1000000) + " Juta" + AmountInWords(x % 1000000);
            }
            return temp;
        }

        public static string PercentageToWords(this double percentage)
        {
            if (percentage == 0)
                return "nol Persen";

            if (percentage < 0)
                return "minus " + PercentageToWords(Math.Abs(percentage));

            int intPart = (int)percentage;
            double decPart = percentage - intPart;

            string words = AmountInWords(intPart).Trim() + " Persen";

            if (decPart > 0)
            {
                int cents = (int)(decPart * 100);
                words += " koma " + AmountInWords(cents).Trim() + " Persen";
            }

            return words;
        }

        public static string PercentageToWords(this float percentage)
        {
            if (percentage == 0)
                return "nol Persen";

            if (percentage < 0)
                return "minus " + PercentageToWords(Math.Abs(percentage));

            int intPart = (int)percentage;
            double decPart = percentage - intPart;

            string words = AmountInWords(intPart).Trim() + " Persen";

            if (decPart > 0)
            {
                int cents = (int)(decPart * 100);
                words += " koma " + AmountInWords(cents).Trim() + " Persen";
            }

            return words;
        }

        public static string CreditPurposeIND(this string purpose)
        {
            if (purpose == null)
                purpose  = "-";

            if (purpose ==  "Consumtive")
                purpose = "Konsumtif";

            if (purpose ==  "Working Capital")
                purpose = "Modal Kerja";

            if (purpose ==  "Investation")
                purpose =  "Investasi";

            return purpose;
        }

        public static string TanggalKeTerbilang(this DateTime tanggal)
        {
            string[] bagianTanggal = tanggal.ToString("dd MMMM yyyy").Split(' ');

            StringInfo hari = new StringInfo(bagianTanggal[0]);
            StringInfo bulan = new StringInfo(bagianTanggal[1]);
            StringInfo tahun = new StringInfo(bagianTanggal[2]);

            var tgl  =  tanggal.ToString("dd-MM-yyyy", culture);
            int day  =  tanggal.Day;
            int year =  tanggal.Year;

            string tanggalTerbilang = " tanggal " + day.AmountInWords() + 
                                      " bulan "+ tanggal.ToString("MMMM", culture) +
                                      " tahun " + year.AmountInWords() + 
                                      "(" + tgl + ")";
            return tanggalTerbilang;
        }
    }
}
