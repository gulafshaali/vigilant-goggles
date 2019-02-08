using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Fen_Test.Authorization;

namespace Fen_Test
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(Fen_TestCoreModule)
        )]
    public class Fen_TestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Fen_TestApplicationModule).GetAssembly());
        }
    }
}