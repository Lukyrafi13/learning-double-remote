using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Constants
{
    public static class UMKMConst
    {
        public static Dictionary<string, Guid> Stages = new()
        {
            { "TidakDiproses", Guid.Parse("0BEFD1A8-C24B-4D3F-8B10-3BAEE7395787") },
            { "Prospect", Guid.Parse("BA81F358-A7A4-4EBF-89C9-3CDB63CE29C9") },
            { "InitialDateEntry", Guid.Parse("1FBE4B9F-1B6C-4056-9054-7BBA1AE614E2") },
            { "SIKPChecking", Guid.Parse("FD559C9B-20F6-4AB7-87D3-1E76E0712316") },
            { "SLIKRequest", Guid.Parse("3C2D8CD5-8D40-4D2D-B6D1-9A49E9358105") },
            { "SLIKRequestAKBL", Guid.Parse("DC3DE7C9-7357-4B50-AA7C-7FD067B619AC") },
            { "SLIKAdmin", Guid.Parse("9B899686-9729-449D-B174-367274B88D7D") },
            { "Analisa", Guid.Parse("DD78F449-A938-4FA9-89A4-5A525BEA1389") },
            { "Review", Guid.Parse("F472D96D-BF21-4B4D-B3F4-FC055E5F0086") },
            { "Approval", Guid.Parse("9F02AD03-9051-4C9B-ABE4-F52BE0E2AB33") },
            { "SPPK", Guid.Parse("E4782B68-F681-4763-9B7D-9E5280CEC655") },
            { "PersiapanAkad", Guid.Parse("E9284093-536C-451E-8A22-8C1ABEE3D600") },
            { "VerifikasiPersiapanAkad", Guid.Parse("4E86557E-749D-40FA-B124-6B144B148450") },
            { "ReviewPersiapanAkad", Guid.Parse("F407255D-CFCB-473C-95B7-5C3C9393B6BF") },
            { "Disbursement", Guid.Parse("A2BDB4AF-AFEC-4C7E-904B-35A3F8F0F799") },
            { "Prescreening", Guid.Parse("9519207D-2D19-4572-913B-B0D709B8D9EC") },
            { "Survey", Guid.Parse("75373BE3-EB23-4B93-8209-1ECD603FB3BA") },
            { "AppraisalApproval", Guid.Parse("C82E6D6F-4ECA-4B77-922C-81F268C4018F") },
            { "AppraisalAsignment", Guid.Parse("F6164295-F21D-41DF-8C46-089779D0D1DD") },
            { "AppraisalSurveyor", Guid.Parse("453019B3-7950-4AE0-8387-2973E8C274B2") },
        };

        public static Dictionary<string, Guid> Roles = new()
        {
            { "BisnisLegal", Guid.Parse("96C6F2C2-8DC2-478B-8C77-225818BA1E5B") },
            { "SUPERADMIN", Guid.Parse("A096AE41-6DBC-4B12-AFEA-3A40AE9981E2") },
            { "AdministrasiOperasional", Guid.Parse("8D2B021F-66AB-4315-8940-77473F9FAD2A") },
            { "PemimpinKantorCabang", Guid.Parse("E9C23B57-C0AF-4FE3-AA50-9A27610F86BA") },
            { "Supervisor", Guid.Parse("18B70AB8-F48C-4B66-90C3-A630724C1622") },
            { "ManagerBisnis", Guid.Parse("D2A3EFFE-C173-4869-AB56-AA695775B2C7") },
            { "OfficerOperasionalKredit", Guid.Parse("AC84104B-C478-49EC-B6CC-CBA5E711DA7C") },
            { "AccountOfficerUMKM", Guid.Parse("CB409959-9416-4C35-9AE8-EB905C3DE1A") },
        };

    }
}
