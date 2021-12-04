using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces.Services;
using Domain.Domain.Interfaces;
using Domain.Entities.Models;
using Infraestructure.Data.Repositories;
namespace Service.Main
{
    public class PaymentService : BaseService<Payment>, IPaymentService
    {

        protected IPaymentRepository repository;
        protected ITransactionRepository transactionRepository;

        public PaymentService(IPaymentRepository repository, ITransactionRepository transactionRepository) : base(repository)
        {
            this.repository = repository;
            this.transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Adding new payment to invoices
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public IEnumerable<Payment> AddPaymetToInvoices(IEnumerable<Invoice> invoices)
        {
            List<Payment> payments = new List<Payment>();

            foreach (var item in invoices)
            {
                Payment p = new Payment();
                p.Invoice = item;
                p.InvoiceId = item.Id;

                payments.Add(p);
            }

            //If Exists an error we doesn't continue
            if (!this.repository.addRange(payments)) return null;

            //Updating transaction status to paid
            payments.ForEach(x => x.Invoice.Transaction.InvoiceStatusId = 3);

            if(!this.transactionRepository.updateRange(payments.Select(x => x.Invoice.Transaction))) return null;

            return payments;
        }

    }
}
