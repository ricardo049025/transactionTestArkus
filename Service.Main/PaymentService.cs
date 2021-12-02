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

        public PaymentService(IPaymentRepository repository) : base(repository)
        {
            this.repository = repository;
        }

    }
}
