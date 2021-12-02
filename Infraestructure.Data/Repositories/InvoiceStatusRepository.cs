using Domain.Entities;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces;
namespace Infraestructure.Data.Repositories
{
    public class InvoiceStatusRepository : BaseRepository<InvoiceStatus>, IInvoiceStatusRepository
    {
        protected ApiContext context;

        public InvoiceStatusRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}
