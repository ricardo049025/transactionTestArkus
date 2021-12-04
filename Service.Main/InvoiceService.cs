using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;
namespace Service.Main
{
    public class InvoiceService : BaseService<Invoice>, IInvoiceService
    {
        protected IInvoiceRepository repository;
        protected ITransactionRepository transactionRepository;

        public InvoiceService(IInvoiceRepository repository, ITransactionRepository transactionRepository) : base(repository)
        {
            this.repository = repository;
            this.transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Transactions that are billed must be 
        /// marked as billed when the invoice is generated
        /// </summary>
        /// <returns></returns>
        public bool invoiceTransaction(IEnumerable<Transaction> transactions)
        {
            List<Invoice> invoices = new List<Invoice>();
            int id = 1;
            foreach (var item in transactions)
            {
                Invoice invoice = new Invoice();                
                invoice.DateInvoce = DateTime.Now;
                invoice.Transaction = item;
                invoice.TransactionId = item.Id;                
                invoices.Add(invoice);
            }

            //IF exists an error doesn't continue
            if (!this.repository.addRange(invoices)) return false;

            //updating all transactions to billed
            transactions.ToList().ForEach(x => x.InvoiceStatusId = 2);

            return (this.transactionRepository.updateRange(transactions));
            

        }

        public IEnumerable<Invoice> getAllInvoiceWithTransaction()
        {
            return this.repository.getInvoiceTransaction();
        }

        

    }
}
