using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Fen_Test
{
    [DependsOn(typeof(Fen_TestClientModule), typeof(AbpAutoMapperModule))]
    public class Fen_TestXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Fen_TestXamarinSharedModule).GetAssembly());
        }
    }
}