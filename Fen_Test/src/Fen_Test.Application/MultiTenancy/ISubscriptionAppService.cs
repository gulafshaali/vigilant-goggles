using System.Threading.Tasks;
using Abp.Application.Services;

namespace Fen_Test.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
