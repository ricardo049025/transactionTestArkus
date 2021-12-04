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

        /// <summary>
        /// Ricardo Martinez.
        /// Method for generate Transactions 
        /// betweens date ranges
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>
        public IEnumerable<Transaction> GenerateTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            DateTime start = startDate;
            Random random = new Random();
            List<Transaction> transactions = new List<Transaction>();

            for (int i = 0; i < (endDate - startDate).TotalDays; i++)
            {
                Transaction tran = new Transaction();
                tran.Date = start.AddDays((i + 1));
                tran.Amount = random.Next(500, 10000);
                tran.Description = $"Transaction No {(i + 1)} by Amount of ${tran.Amount}";
                tran.InvoiceStatusId = 1;
                transactions.Add(tran);
            }

            this.repository.addRange(transactions);

            return transactions;
        }

        public bool existsTransaction(int id)
        {
            return (repository.getById(id) == null ? false : true);
        }
        

    }
}
