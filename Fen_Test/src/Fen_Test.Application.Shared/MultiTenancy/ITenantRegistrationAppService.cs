using System.Threading.Tasks;
using Abp.Application.Services;
using Fen_Test.Editions.Dto;
using Fen_Test.MultiTenancy.Dto;

namespace Fen_Test.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}