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
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        protected ApiContext context;

        public PaymentRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}
