using System.Threading.Tasks;
using Abp.Dependency;

namespace Fen_Test.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}