using System;
using Fen_Test.Core;
using Fen_Test.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fen_Test.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}