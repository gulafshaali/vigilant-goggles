using Abp.Domain.Services;

namespace Fen_Test
{
    public abstract class Fen_TestDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected Fen_TestDomainServiceBase()
        {
            LocalizationSourceName = Fen_TestConsts.LocalizationSourceName;
        }
    }
}
