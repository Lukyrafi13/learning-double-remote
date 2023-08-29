using Bjb.DigitalBisnis.CoreBanking.Delegates;
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
using Bjb.DigitalBisnis.CoreBanking.Models.DealEventCreditEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.DealEventDepositoEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.DealEventEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.EA;
using Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold;
using Bjb.DigitalBisnis.CoreBanking.Models.InterAccountTransfer;
using Bjb.DigitalBisnis.CoreBanking.Models.MaintainDeleteAccountBasicHold;
using Bjb.DigitalBisnis.CoreBanking.Models.OpenCustomerAccount;
using Bjb.DigitalBisnis.CoreBanking.Models.RLP;
using Bjb.DigitalBisnis.CoreBanking.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;
using System;
using System.Reflection;
using System.Text.Json;

namespace Bjb.DigitalBisnis.CoreBanking
{
    public static class ServiceRegistration
    {
        private const string CONFIGURATION_NAME = "CoreBankingApi";
        public static void AddCoreBankinAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpLoggingHandler>();
            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,       
                
            };

            var settings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(options)
            };
            CoreBankingOptionModel option = new CoreBankingOptionModel();
            services.AddValidatorsFromAssembly(Assembly.Load("Bjb.DigitalBisnis.CoreBanking"));
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountBalanceEnquiryRequest>>, AccountBalanceEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountBasicDetailEnquiryRequest>>, AccountBasicDetailEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountListRequest>>, AccountListValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountSummaryEnquiryRequest>>, AccountSummaryEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountTransactionHistoryRequest>>, AccountTransactionHistoryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AdditionalAccountInformationRequest>>, AdditionalAccountInformationValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AdditionalCustomerInformationRequest>>, AdditionalCustomerInformationValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AdditionalDealInformationRequest>>, AdditionalDealInformationValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AdditionalInformationEnquiryRequest>>, AdditionalInformationEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AddNewCustomerRequest>>, AddNewCustomerValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AddRetailLoanRequest>>, AddRetailLoanValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<CustomerAccountAddressRequest>>, CustomerAccountAddressValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<DealEventCreditEnquiryRequest>>, DealEventCreditEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<DealEventDepositoEnquiryRequest>>, DealEventDepositoEnquiryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<InputAccountHoldRequest>>, InputAccountHoldValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<InterAccountTransferRequest>>, InterAccountTransferValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<MaintainDeleteAccountBasicHoldRequest>>, MaintainDeleteAccountBasicHoldValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<OpenCustomerAccountRequest>>, OpenCustomerAccountValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<RLPRequest>>, RLPValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<AccountTransactionHistoryRequest>>, AccountTransactionHistoryValidator>();
            services.AddScoped<IValidator<BaseCoreBankingRequest<EARequest>>, EAValidator>();
            services.Configure<CoreBankingOptionModel>(configuration.GetSection(CONFIGURATION_NAME));
            configuration.GetSection("CoreBankingApi").Bind(option);
            services.AddRefitClient<ICoreBankingAPI>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(option.IpAddress);
            })
            .AddHttpMessageHandler<HttpLoggingHandler>();
            services.AddTransient(typeof(ICoreBankingService<,>), typeof(CoreBankingService<,>));
        }
    }
}
