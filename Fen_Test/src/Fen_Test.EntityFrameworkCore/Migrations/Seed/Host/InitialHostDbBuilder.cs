using Fen_Test.EntityFrameworkCore;

namespace Fen_Test.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly Fen_TestDbContext _context;

        public InitialHostDbBuilder(Fen_TestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
