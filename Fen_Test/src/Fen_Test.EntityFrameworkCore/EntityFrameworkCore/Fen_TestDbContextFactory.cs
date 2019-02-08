using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Fen_Test.Configuration;
using Fen_Test.Web;

namespace Fen_Test.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Fen_TestDbContextFactory : IDesignTimeDbContextFactory<Fen_TestDbContext>
    {
        public Fen_TestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Fen_TestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            Fen_TestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Fen_TestConsts.ConnectionStringName));

            return new Fen_TestDbContext(builder.Options);
        }
    }
}