using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Fen_Test
{
    public class Fen_TestClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Fen_TestClientModule).GetAssembly());
        }
    }
}
