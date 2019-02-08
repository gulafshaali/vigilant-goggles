using Abp.AspNetCore.Mvc.ViewComponents;

namespace Fen_Test.Web.Views
{
    public abstract class Fen_TestViewComponent : AbpViewComponent
    {
        protected Fen_TestViewComponent()
        {
            LocalizationSourceName = Fen_TestConsts.LocalizationSourceName;
        }
    }
}