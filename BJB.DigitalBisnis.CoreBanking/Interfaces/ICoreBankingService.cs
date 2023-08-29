using Bjb.DigitalBisnis.CoreBanking.Models;
using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.AccountBasicDetailEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.AccountList;
using Bjb.DigitalBisnis.CoreBanking.Models.AccountSummaryEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.AccountTransactionHistory;
using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalAccountInformation;
using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalCustomerInformation;
using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalDealInformation;
using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalInformationEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.AddNewCustomer;
using Bjb.DigitalBisnis.CoreBanking.Models.AddRetailLoan;
using Bjb.DigitalBisnis.CoreBanking.Models.CustomerAccountAddress;
using Bjb.DigitalBisnis.CoreBanking.Models.DealEventDepositoEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.DealEventEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.EA;
using Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold;
using Bjb.DigitalBisnis.CoreBanking.Models.InterAccountTransfer;
using Bjb.DigitalBisnis.CoreBanking.Models.MaintainDeleteAccountBasicHold;
using Bjb.DigitalBisnis.CoreBanking.Models.OpenCustomerAccount;
using Bjb.DigitalBisnis.CoreBanking.Models.RLP;
using Bjb.DigitalBisnis.CoreBanking.Models.TransactionHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Interfaces
{
    public interface ICoreBankingService<T1, T2> where T1 : class where T2 : class
    {
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AccountBalanceEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AccountListRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AccountSummaryEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AccountTransactionHistoryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AdditionalAccountInformationRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AdditionalCustomerInformationRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AdditionalDealInformationRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AdditionalInformationEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AddNewCustomerRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<AddRetailLoanRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<CustomerAccountAddressRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<DealEventCreditEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<DealEventDepositoEnquiryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<InputAccountHoldRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<InterAccountTransferRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<OpenCustomerAccountRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<TransactionHistoryRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<RLPRequest> request);
        Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<EARequest> request);
    }
}
