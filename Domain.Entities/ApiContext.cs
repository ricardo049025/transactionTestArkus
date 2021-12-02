using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }

        public DbSet<InvoiceStatus> InvoiceStatuses { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Invoice> invoices { set; get; }
        public DbSet<Payment> payments { set; get; }

    }
}
