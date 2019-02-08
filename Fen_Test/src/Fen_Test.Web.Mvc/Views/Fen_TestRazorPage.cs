using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Fen_Test.Web.Views
{
    public abstract class Fen_TestRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected Fen_TestRazorPage()
        {
            LocalizationSourceName = Fen_TestConsts.LocalizationSourceName;
        }
    }
}
