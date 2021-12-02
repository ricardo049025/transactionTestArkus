using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;

namespace Infraestructure.Data.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        protected ApiContext context;

        public InvoiceRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}
