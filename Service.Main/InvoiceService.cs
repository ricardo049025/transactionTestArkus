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

        public InvoiceService(IInvoiceRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
