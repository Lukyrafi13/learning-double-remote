using AutoMapper;
using NewLMS.UMKM.API.Helpers.Mapping.Transactions;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public static class MapperConfig
    {
        public static IMapper GetMapperConfigs()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ReferenceProfile());
                mc.AddProfile(new ProspectProfile());
                mc.AddProfile(new DebtorProfile());
                mc.AddProfile(new DebtorCoupleProfile());
                mc.AddProfile(new DebtorCompanyProfile());
                mc.AddProfile(new DebtorEmergencyProfile());
                mc.AddProfile(new LoanApplicationProfile());
                mc.AddProfile(new LoanApplicationCreditScoringProfile());

            });
            return mappingConfig.CreateMapper();
        }
    }
}
