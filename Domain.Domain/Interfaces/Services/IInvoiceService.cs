using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;
namespace Domain.Domain.Interfaces.Services
{
    public interface IInvoiceService : IBaseService<Invoice>
    {
        bool invoiceTransaction(IEnumerable<Transaction> transactions);
        IEnumerable<Invoice> getAllInvoiceWithTransaction();
        
    }
}
