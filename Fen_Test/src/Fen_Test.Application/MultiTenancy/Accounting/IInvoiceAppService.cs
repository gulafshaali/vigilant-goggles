using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Fen_Test.MultiTenancy.Accounting.Dto;

namespace Fen_Test.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
