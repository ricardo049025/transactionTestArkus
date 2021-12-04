using Domain.Domain.DTO;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {        
        private readonly ILogger<TransactionController> _logger;
        private IInvoiceStatusService service;
        private ITransactionService transactionService;
        private IInvoiceService invoiceService;
        private IPaymentService paymentService;

        public TransactionController(ILogger<TransactionController> logger, IInvoiceStatusService service, ITransactionService transactionService, IInvoiceService invoiceService, IPaymentService paymentService)
        {
            _logger = logger;
            this.service = service;
            this.transactionService = transactionService;
            this.invoiceService = invoiceService;
            this.paymentService = paymentService;
        }

        /// <summary>
        /// Ricardo Martinez. 
        /// Creating transactions from request 
        /// of the host or any client.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Transaction> GetInvoices()
        {
            return transactionService.getAll();
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Method for create new transactions
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addTransaction")]
        public Transaction PostTransaction([FromBody] Transaction transaction)
        {
            if (!this.transactionService.add(transaction)) return null;

            return transaction;
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Method for update status 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateTransaction/{id:int}")]
        public ActionResult PutTransaction(int id,[FromBody] Transaction transaction)
        {
            
            if(!this.transactionService.existsTransaction(id)) return StatusCode(StatusCodes.Status404NotFound, "Error retrieving data from the database");

            transactionService.update(transaction);

            return Ok("Updated");

        }

        /// <summary>
        /// Ricardo Martinez.
        /// Method for create invoices 
        /// from two dates range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addTransactionByDateRange")]
        public List<Transaction> PostTransactionByDateRange([FromBody] DateRange dateRange)
        {
            //Creating invoices
            return this.transactionService.GenerateTransactionsByDateRange(dateRange.startDate, dateRange.endDate).ToList();           
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Generate billed Transaction
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("invoiceTransaction")]
        public List<Invoice> PostinvoiceTransaction([FromBody] Transaction[] transactions)        
        {
            if(!this.invoiceService.invoiceTransaction(transactions)) return null;

            return this.invoiceService.getAll().ToList();
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Method 
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addPayments")]
        public IEnumerable<Payment> PostAddPayments([FromBody] Invoice[] invoices)
        {
            return this.paymentService.AddPaymetToInvoices(invoices);            
        }


    }
}
