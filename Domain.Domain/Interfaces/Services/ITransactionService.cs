using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;
namespace Domain.Domain.Interfaces.Services
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        IEnumerable<Transaction> GenerateTransactionsByDateRange(DateTime startDate, DateTime endDate);
        bool existsTransaction(int id);
    }
}
