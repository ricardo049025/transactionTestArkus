using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.Models;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Service.Main;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TestArkusProject
{
    public class TransactionTests
    {
        //Variable for use
        #region. Atribute of the test

        private DbContextOptions<ApiContext> options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase(databaseName: "dbArkus").Options;
        private IInvoiceStatusRepository invoiceStatusRepository;
        private ITransactionRepository transactionRepository;
        private IInvoiceRepository invoiceRepository;

        private IInvoiceStatusService invoiceStatusService;
        private ITransactionService transactionService;
        private IInvoiceService invoiceService;


        private ApiContext context;

        #endregion

        #region Constructor of the test
        public TransactionTests()
        {
            context = new ApiContext(options);
            invoiceStatusRepository = new InvoiceStatusRepository(context);
            transactionRepository = new TransactionRepository(context);
            invoiceRepository = new InvoiceRepository(context);

            invoiceStatusService = new InvoiceStatusService(invoiceStatusRepository);
            transactionService = new TransactionService(transactionRepository);
            invoiceService = new InvoiceService(invoiceRepository);
        }
        #endregion

        #region Invoice Status Tests

        /// <summary>
        /// Ricardo Martinez. 
        /// Method for Add Invoice Status records
        /// to table
        /// </summary>
        [Test]        
        public void AddInvoiceStatus()
        {
            List<InvoiceStatus> listInvoiceStatus = new List<InvoiceStatus>();

                InvoiceStatus record = new InvoiceStatus();
                record.Name = "Not Billed";
                record.Status = true;

                listInvoiceStatus.Add(record);

                InvoiceStatus record2 = new InvoiceStatus();
                record2.Name = "Billed";
                record2.Status = true;

                listInvoiceStatus.Add(record2);

                InvoiceStatus record3 = new InvoiceStatus();
                record3.Name = "Paid";
                record3.Status = true;

                listInvoiceStatus.Add(record3);

            Assert.AreEqual(true, invoiceStatusService.addRange(listInvoiceStatus));
        }

        /// <summary>
        /// Ricardo Martinez.
        /// Test for Generate Transaction by Date Range
        /// </summary>
        [Test]
        public void GenerateTransactionsByDateRange()
        {
            DateTime startDate = new DateTime(2021,12,1);
            DateTime endDate = new DateTime(2021, 12, 15);

            Assert.AreEqual(true, transactionService.GenerateTransactionsByDateRange(startDate, endDate));
        }

        /// <summary>
        /// Ricardo Martinez
        /// Generate billed Transaction
        /// </summary>
        [Test]
        public void invoiceTransaction()
        {
            //Generating transactions
            DateTime startDate = new DateTime(2021, 12, 1);
            DateTime endDate = new DateTime(2021, 12, 15);            
            transactionService.GenerateTransactionsByDateRange(startDate, endDate);

            //Retrive transactions to invoice
            IEnumerable<Transaction> transactions = transactionService.getAll().Take(5);
           
            

        }

        #endregion
    }
}