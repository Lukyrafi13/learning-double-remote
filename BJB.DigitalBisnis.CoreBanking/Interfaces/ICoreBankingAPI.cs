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
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Interfaces
{
    public interface ICoreBankingAPI
    {
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AccountBalanceEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<InterAccountTransferRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AdditionalInformationEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<InputAccountHoldRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<DealEventCreditEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<DealEventDepositoEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<TransactionHistoryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AccountTransactionHistoryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AddRetailLoanRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AccountListRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AccountSummaryEnquiryRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AddNewCustomerRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<OpenCustomerAccountRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<CustomerAccountAddressRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AdditionalDealInformationRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AdditionalCustomerInformationRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<AdditionalAccountInformationRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<RLPRequest> request);
        [Post("/gtwcore")]
        Task<HttpResponseMessage> GatewayCore([Body(BodySerializationMethod.Serialized)] BaseCoreBankingRequest<EARequest> request);
    }
}
