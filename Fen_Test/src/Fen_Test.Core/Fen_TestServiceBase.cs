using Abp;

namespace Fen_Test
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="Fen_TestDomainServiceBase"/>.
    /// For application services inherit Fen_TestAppServiceBase.
    /// </summary>
    public abstract class Fen_TestServiceBase : AbpServiceBase
    {
        protected Fen_TestServiceBase()
        {
            LocalizationSourceName = Fen_TestConsts.LocalizationSourceName;
        }
    }
}