using Microsoft.Extensions.Configuration;

namespace Fen_Test.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
