using NewLMS.UMKM.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Common.GenericRespository
{
    public class UMKMStage
    {
        public int ProcessStatus;
        public Guid StageId;
        public string Code;

        public UMKMStage(int processStatus, Guid stageId, string code)
        {
            ProcessStatus = processStatus;
            StageId = stageId;
            Code = code;
        }
    }
    public static class CommonConstants
    {

        public static Dictionary<string, Type> ConverterMapings = new Dictionary<string, Type>
        {
            { "string", typeof(string) },
            { "int", typeof(int) },
            { "bool",typeof(bool) },
            { "guid", typeof(Guid) },
            { "date", typeof(DateTime)},
            { "raw", typeof(string)},
            { "AnalisaStatus", typeof(EnumAnalisaStatus)},
        };


    }

    public static class CoreBankingStatusCode
    {
        public static  readonly string Success = "0000";
    }

    public static class CoreBankingServiceCode
    {
        public static readonly string RLA = "RLA";
        public static readonly string DIM = "DIM";
        public static readonly string RLP = "RLP";
        public static readonly string AAH = "AAH";
    }

    public static class CoreBankingSubmissionType
    {
        public static string NEW = "1";
        public static string MENGULANG = "2";
        public static string TOPUP = "3";
    }

    public static class CoreBankingDefaultValues
    {
        public static string BUPSQ = "00000";
        public static string BUD011 = "2";
        public static string BUD015 = "3";
        public static string BUD019 = "2";
        public static string BUD089 = "13";
        public static string BUD107 = "3";
        public static string BUD112 = "M";
        public static string BUEQF = "DL";
        public static string BUIGR = "DL02";
    }

    public static class LMSUMKMStages
    {
        public static UMKMStage Prospect = new UMKMStage(0, Guid.Parse("815844CD-1BE0-2B85-21CF-6F41ECCA82E6"), "0.0");

        public static UMKMStage ProspectHistory = new UMKMStage(1, Guid.Parse("815844CD-1BE0-2B85-21CF-6F41ECCA82E6"), "0.0");

        public static UMKMStage InitialData = new UMKMStage(0, Guid.Parse("1FBE4B9F-1B6C-4056-9054-7BBA1AE614E2"), "2.0");

        public static UMKMStage SLIKRequest = new UMKMStage(0, Guid.Parse("B5B1D55C-C1E0-E0BF-E8DF-4B4A5A873F10"), "2.1");

        public static UMKMStage SLIKRequestAKBL = new UMKMStage(1, Guid.Parse("1CB26156-D77A-26F8-14F9-43DE17F99970"), "2.2");

        public static UMKMStage SLIKAdmin = new UMKMStage(3, Guid.Parse("D1218E0F-6722-214F-C48E-8B6D0FD475C6"), "2.3");

        public static UMKMStage Dokumen = new UMKMStage(5, Guid.Parse("B0C824D0-9D89-F851-10BA-6BDEA7A1A40F"), "2.4");

        public static UMKMStage Duplikasi = new UMKMStage(7, Guid.Parse("4C385A55-D011-3CB7-A309-30BDFB407B90"), "2.5");
        
        public static UMKMStage AppraisalAsignment = new UMKMStage(0, Guid.Parse("F6164295-F21D-41DF-8C46-089779D0D1DD"), "13.1");
        
        public static UMKMStage AppraisalSurveyor = new UMKMStage(0, Guid.Parse("453019B3-7950-4AE0-8387-2973E8C274B2"), "13.2");
        
        public static UMKMStage AppraisalApproval = new UMKMStage(0, Guid.Parse("C82E6D6F-4ECA-4B77-922C-81F268C4018F"), "13.3");

        public static UMKMStage Analisa = new UMKMStage(0, Guid.Parse("DD78F449-A938-4FA9-89A4-5A525BEA1389"), "5.0");

        public static UMKMStage Review = new UMKMStage(11, Guid.Parse("55EAB4A7-025C-4F4B-B465-51F892EEE356"), "4.0");

        public static UMKMStage Approval = new UMKMStage(13, Guid.Parse("424C2280-CAE3-F88A-0C30-340875A46254"), "4.1");

        public static UMKMStage SP3K = new UMKMStage(15, Guid.Parse("81A246ED-1B34-4627-BB2D-A2478EC50FF4"), "5.0");

        public static UMKMStage PersiapanAkad = new UMKMStage(17, Guid.Parse("B9C4DCDA-956B-DAFD-DE36-CE763EEE95A1"), "6.0");

        public static UMKMStage PersiapanAkadReview = new UMKMStage(19, Guid.Parse("35A16E69-42EE-4EA8-B063-DB53E9A4E37B"), "6.1");

        public static UMKMStage Disbursement = new UMKMStage(21, Guid.Parse("3433A923-6338-40F1-A40B-73A2ABC13B63"), "7.0");
    }
}
