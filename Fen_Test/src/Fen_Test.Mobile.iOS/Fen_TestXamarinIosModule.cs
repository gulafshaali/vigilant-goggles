using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Fen_Test
{
    [DependsOn(typeof(Fen_TestXamarinSharedModule))]
    public class Fen_TestXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Fen_TestXamarinIosModule).GetAssembly());
        }
    }
}