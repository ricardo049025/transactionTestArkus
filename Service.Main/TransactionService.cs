using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;
using Domain.Domain.Interfaces.Services;
using Infraestructure.Data.Repositories;
using Domain.Domain.Interfaces;

namespace Service.Main
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        public ITransactionRepository repository;

        public TransactionService(ITransactionRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
