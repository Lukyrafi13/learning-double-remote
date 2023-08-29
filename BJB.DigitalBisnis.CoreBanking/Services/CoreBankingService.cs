using Bjb.DigitalBisnis.CoreBanking.Interfaces;
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
using FluentValidation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Services
{
    public class CoreBankingService<T1, T2> : ICoreBankingService<T1, T2> where T1 : class where T2 : class
    {
        private readonly ICoreBankingAPI _coreBankingAPI;
        private readonly ILogger<CoreBankingService<T1, T2>> _logger;

        private readonly IValidator<BaseCoreBankingRequest<AccountBalanceEnquiryRequest>>
            _validatorAccountBalanceEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest>>
            _validatorAccountBasicDetailEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<AccountListRequest>> _validatorAccountList;

        private readonly IValidator<BaseCoreBankingRequest<AccountSummaryEnquiryRequest>>
            _validatorAccountSummaryEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<AccountTransactionHistoryRequest>>
            _validatorAccountTransactionHistory;

        private readonly IValidator<BaseCoreBankingRequest<AdditionalAccountInformationRequest>>
            _validationAdditionalAccountInformation;

        private readonly IValidator<BaseCoreBankingRequest<AdditionalCustomerInformationRequest>>
            _validationAdditionalCustomerInformation;

        private readonly IValidator<BaseCoreBankingRequest<AdditionalDealInformationRequest>>
            _validationAdditionalDealInformation;

        private readonly IValidator<BaseCoreBankingRequest<AddNewCustomerRequest>> _validationAddNewCustomer;
        private readonly IValidator<BaseCoreBankingRequest<AddRetailLoanRequest>> _validationAddRetailLoan;

        private readonly IValidator<BaseCoreBankingRequest<CustomerAccountAddressRequest>>
            _validationCustomerAccountAddress;

        private readonly IValidator<BaseCoreBankingRequest<DealEventCreditEnquiryRequest>>
            _validationDealEventCreditEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<DealEventDepositoEnquiryRequest>>
            _validationDealEventDepositoEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<InputAccountHoldRequest>> _validationInputAccountHold;

        private readonly IValidator<BaseCoreBankingRequest<InterAccountTransferRequest>>
            _validationInterAccountTransfer;

        private readonly IValidator<BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest>>
            _validationMaintainDeleteAccountBasicHold;

        private readonly IValidator<BaseCoreBankingRequest<OpenCustomerAccountRequest>> _validationOpenCustomerAccount;
        private readonly IValidator<BaseCoreBankingRequest<TransactionHistoryRequest>> _validationTransactionHistory;

        private readonly IValidator<BaseCoreBankingRequest<AdditionalInformationEnquiryRequest>>
            _validationAdditionalInformationEnquiry;

        private readonly IValidator<BaseCoreBankingRequest<RLPRequest>> _validationRLP;
        private readonly IValidator<BaseCoreBankingRequest<EARequest>> _validationEA;

        public CoreBankingService(
            ICoreBankingAPI coreBankingAPI,
            ILogger<CoreBankingService<T1, T2>> logger,
            IValidator<BaseCoreBankingRequest<AccountBalanceEnquiryRequest>> validatorAccountBalanceEnquiry,
            IValidator<BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest>> validatorAccountBasicDetailEnquiry,
            IValidator<BaseCoreBankingRequest<AccountListRequest>> validatorAccountList,
            IValidator<BaseCoreBankingRequest<AccountSummaryEnquiryRequest>> validatorAccountSummaryEnquiry,
            IValidator<BaseCoreBankingRequest<AccountTransactionHistoryRequest>> validatorAccountTransactionHistory,
            IValidator<BaseCoreBankingRequest<AdditionalAccountInformationRequest>>
                validationAdditionalAccountInformation,
            IValidator<BaseCoreBankingRequest<AdditionalCustomerInformationRequest>>
                validationAdditionalCustomerInformation,
            IValidator<BaseCoreBankingRequest<AdditionalDealInformationRequest>> validationAdditionalDealInformation,
            IValidator<BaseCoreBankingRequest<AddNewCustomerRequest>> validationAddNewCustomer,
            IValidator<BaseCoreBankingRequest<AddRetailLoanRequest>> validationAddRetailLoan,
            IValidator<BaseCoreBankingRequest<CustomerAccountAddressRequest>> validationCustomerAccountAddress,
            IValidator<BaseCoreBankingRequest<DealEventCreditEnquiryRequest>> validationDealEventCreditEnquiry,
            IValidator<BaseCoreBankingRequest<DealEventDepositoEnquiryRequest>> validationDealEventDepositoEnquiry,
            IValidator<BaseCoreBankingRequest<InputAccountHoldRequest>> validationInputAccountHold,
            IValidator<BaseCoreBankingRequest<InterAccountTransferRequest>> validationInterAccountTransfer,
            IValidator<BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest>>
                validationMaintainDeleteAccountBasicHold,
            IValidator<BaseCoreBankingRequest<OpenCustomerAccountRequest>> validationOpenCustomerAccount,
            IValidator<BaseCoreBankingRequest<TransactionHistoryRequest>> validationTransactionHistory,
            IValidator<BaseCoreBankingRequest<AdditionalInformationEnquiryRequest>>
                validationAdditionalInformationEnquiry,
            IValidator<BaseCoreBankingRequest<RLPRequest>> validationRLP,
            IValidator<BaseCoreBankingRequest<EARequest>> validationEA)
        {
            _coreBankingAPI = coreBankingAPI;
            _logger = logger;
            _validatorAccountBalanceEnquiry = validatorAccountBalanceEnquiry;
            _validatorAccountBasicDetailEnquiry = validatorAccountBasicDetailEnquiry;
            _validatorAccountList = validatorAccountList;
            _validatorAccountSummaryEnquiry = validatorAccountSummaryEnquiry;
            _validatorAccountTransactionHistory = validatorAccountTransactionHistory;
            _validationAdditionalAccountInformation = validationAdditionalAccountInformation;
            _validationAdditionalCustomerInformation = validationAdditionalCustomerInformation;
            _validationAdditionalDealInformation = validationAdditionalDealInformation;
            _validationAddNewCustomer = validationAddNewCustomer;
            _validationAddRetailLoan = validationAddRetailLoan;
            _validationCustomerAccountAddress = validationCustomerAccountAddress;
            _validationDealEventCreditEnquiry = validationDealEventCreditEnquiry;
            _validationDealEventDepositoEnquiry = validationDealEventDepositoEnquiry;
            _validationInputAccountHold = validationInputAccountHold;
            _validationInterAccountTransfer = validationInterAccountTransfer;
            _validationMaintainDeleteAccountBasicHold = validationMaintainDeleteAccountBasicHold;
            _validationOpenCustomerAccount = validationOpenCustomerAccount;
            _validationTransactionHistory = validationTransactionHistory;
            _validationAdditionalInformationEnquiry = validationAdditionalInformationEnquiry;
            _validationRLP = validationRLP;
            _validationEA = validationEA;
        }

        /// <summary>
        /// Account Balance Enquiry - AB
        /// </summary>
        /// <param name="AccountBalanceEnquiryRequest">AccountBalanceEnquiryRequest</param>
        /// <returns>AccountBalanceEnquiryRequest</returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AccountBalanceEnquiryRequest> request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                await _validatorAccountBalanceEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Account Basic Details Inquiry - ABE
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest> request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                await _validatorAccountBasicDetailEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Account List 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AccountListRequest> request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                await _validatorAccountList.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AccountSummaryEnquiryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validatorAccountSummaryEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AccountTransactionHistoryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validatorAccountTransactionHistory.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AdditionalAccountInformationRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAdditionalAccountInformation.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AdditionalCustomerInformationRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAdditionalCustomerInformation.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Additional Deal Information (DIM)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AdditionalDealInformationRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAdditionalDealInformation.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                    _logger.LogInformation(JsonConvert.SerializeObject(data));
                    Console.WriteLine(JsonConvert.SerializeObject(data));
                    return data;
                }
                else
                {
                    throw new Exception(content);
                }


            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AdditionalInformationEnquiryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAdditionalInformationEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AddNewCustomerRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAddNewCustomer.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Retail Loan
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<AddRetailLoanRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationAddRetailLoan.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<CustomerAccountAddressRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationCustomerAccountAddress.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<DealEventCreditEnquiryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationDealEventCreditEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<DealEventDepositoEnquiryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationDealEventDepositoEnquiry.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// AAH
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<InputAccountHoldRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationInputAccountHold.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<InterAccountTransferRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationInterAccountTransfer.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationMaintainDeleteAccountBasicHold.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<OpenCustomerAccountRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationOpenCustomerAccount.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(
            BaseCoreBankingRequest<TransactionHistoryRequest> request)
        {
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                Console.WriteLine(JsonConvert.SerializeObject(request));
                await _validationTransactionHistory.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                _logger.LogInformation(JsonConvert.SerializeObject(data));
                Console.WriteLine(JsonConvert.SerializeObject(data));
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// RLP
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<RLPRequest> request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                await _validationRLP.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {

                    var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                    _logger.LogInformation(JsonConvert.SerializeObject(data));
                    Console.WriteLine(JsonConvert.SerializeObject(data));
                    return data;
                }
                else
                {
                    throw new Exception(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GI33
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseCoreBankingResponse<T1, T2>> CoreBanking(BaseCoreBankingRequest<EARequest> request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                _logger.LogInformation(JsonConvert.SerializeObject(request));
                await _validationEA.ValidateAndThrowAsync(request);
                var res = await _coreBankingAPI.GatewayCore(request);
                var content = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {

                    var data = JsonConvert.DeserializeObject<BaseCoreBankingResponse<T1, T2>>(content);
                    _logger.LogInformation(JsonConvert.SerializeObject(data));
                    Console.WriteLine(JsonConvert.SerializeObject(data));
                    return data;
                }
                else
                {
                    throw new Exception(content);
                }


            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}