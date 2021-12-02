using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infraestructure.Data.Repositories
{
    public class TransactionRepository : BaseRepository<Domain.Entities.Models.Transaction>, ITransactionRepository
    {
        protected ApiContext context;

        public TransactionRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}
