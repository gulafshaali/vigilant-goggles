using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Fen_Test.EntityFrameworkCore
{
    public static class Fen_TestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Fen_TestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Fen_TestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}