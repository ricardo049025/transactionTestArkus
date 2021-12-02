using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Domain.Entities.Models;
namespace Domain.Domain.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Entities.Models.Transaction>
    {

    }

}
