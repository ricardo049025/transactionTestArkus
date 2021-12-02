using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;

namespace Domain.Entities
{
    public class DataSeeder
    {
        public static void Initialize(ApiContext context)
        {

            //creating InvoiceStatus
            context.InvoiceStatuses.AddRange(
                new InvoiceStatus { Id = 1, Name = "not billed", Status = true},
                new InvoiceStatus { Id = 2, Name = "billed", Status = true },
                new InvoiceStatus { Id = 3, Name = "paid", Status = true }
            );

            //creating InvoiceStatus
            context.Transactions.AddRange(
                new Transaction { Id = 1, Date= DateTime.Now, Amount = 100, Description = "Invoice Number 1",  InvoiceStatusId = 1  },
                new Transaction { Id = 2, Date = DateTime.Now, Amount = 100, Description = "Invoice Number 2", InvoiceStatusId = 1 },
                new Transaction { Id = 3, Date = DateTime.Now, Amount = 100, Description = "Invoice Number 3", InvoiceStatusId = 2 },
                new Transaction { Id = 4, Date = DateTime.Now, Amount = 100, Description = "Invoice Number 4", InvoiceStatusId = 2 },
                new Transaction { Id = 5, Date = DateTime.Now, Amount = 100, Description = "Invoice Number 5", InvoiceStatusId = 3 },
                new Transaction { Id = 6, Date = DateTime.Now, Amount = 100, Description = "Invoice Number 6", InvoiceStatusId = 3 }
            );

            context.SaveChanges();
            
        }
    }
}
