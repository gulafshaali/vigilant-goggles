using Abp;
using Abp.Dependency;
using Abp.Localization;
using Abp.Web.Models.AbpUserConfiguration;
using JetBrains.Annotations;
using Fen_Test.Sessions.Dto;

namespace Fen_Test.ApiClient
{
    public class ApplicationContext : IApplicationContext, ISingletonDependency
    {
        public TenantInformation CurrentTenant { get; private set; }

        public AbpUserConfigurationDto Configuration { get; set; }

        public GetCurrentLoginInformationsOutput LoginInfo { get; set; }

        public void SetAsTenant([NotNull] string tenancyName, int tenantId)
        {
            Check.NotNull(tenancyName, nameof(tenancyName));

            CurrentTenant = new TenantInformation(tenancyName, tenantId);
        }

        public LanguageInfo CurrentLanguage { get; set; }

        public void SetAsHost()
        {
            CurrentTenant = null;
        }
    }
}