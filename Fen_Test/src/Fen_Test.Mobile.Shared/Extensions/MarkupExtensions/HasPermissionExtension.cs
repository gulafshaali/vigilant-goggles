using System;
using Fen_Test.Core;
using Fen_Test.Core.Dependency;
using Fen_Test.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fen_Test.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}