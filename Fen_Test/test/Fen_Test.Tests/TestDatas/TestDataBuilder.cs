using Fen_Test.EntityFrameworkCore;

namespace Fen_Test.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly Fen_TestDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(Fen_TestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
