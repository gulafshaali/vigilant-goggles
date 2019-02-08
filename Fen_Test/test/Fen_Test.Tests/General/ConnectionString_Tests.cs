using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Fen_Test.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=Fen_Test; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Fen_Test");
        }
    }
}
