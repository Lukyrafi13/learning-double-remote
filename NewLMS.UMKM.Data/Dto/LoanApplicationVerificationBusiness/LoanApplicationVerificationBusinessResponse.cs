using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceOwnership;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationVerificationBusiness
{
    public class LoanApplicationVerificationBusinessResponse : BaseResponse
    {
        public Guid Id { get; set; }

        //Informasi Omset
        public string InterviewTurnOver { get; set; }
        public string ObservationTurnOver { get; set; }
        public string NotesTurnOver { get; set; }
        public double TurnoverValueTurnOver { get; set; }
        public double AnnualSalesTurnOver { get; set; }
        public double NetWorthTurnOver { get; set; }
        public string BasicConsiderationTurnOver { get; set; }

        //Informasi GPM
        public double InterviewGPM { get; set; }
        public double ObservationGPM { get; set; }
        public double MaximumStandardGPM { get; set; }
        public double LowestGrossProfitMarginGPM { get; set; }
        public double PurchaseCostValueGPM { get; set; }
        public double PurchaseCostPercentGPM { get; set; }

        //Informasi Biaya Usaha
        public double LaborCosts { get; set; }
        public double VenueElectricityCosts { get; set; }
        public double PremisesWaterFees { get; set; }
        public double TelephoneCallFee { get; set; }
        public double CellphoneFee { get; set; }
        public double OperatingCosts { get; set; }
        public double TotalBusinessCost { get; set; }

        //Biaya Rumah Tangga
        public double InterviewHouseHold { get; set; }
        public double HouseholdExpenses { get; set; }
        public double VerificationResultsHouseHold { get; set; }
        public double HighestCostResultsHouseHold { get; set; }

        //Informasi Komponen Modal Kerja
        public double AmountStockpile { get; set; }
        public double AmountReceivable { get; set; }
        public double TotalDebt { get; set; }

        //Analisa Usaha
        public bool FundedBusiness { get; set; }
        public bool BusinessLocation { get; set; }
        public bool DebtorsBusiness { get; set; }

        public string BusinessOwnershipCode { get; set; }
        public int? OldBusinessLocationCode { get; set; }


        public virtual RfBusinessPlaceOwnershipSimpleResponse BusinessPlaceOwnership { get; set; }
        public virtual RfParameterDetailSimpleResponse OldBusinessLocation { get; set; }
    }
}
