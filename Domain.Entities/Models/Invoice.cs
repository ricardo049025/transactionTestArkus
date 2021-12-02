using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Invoice
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string DateInvoce { set; get; }

        [ForeignKey("TransactionId")]
        public int? TransactionId { set; get; }
        public virtual Transaction Transaction { set; get; }

        public List<Payment> payments { get; } = new List<Payment>();
    }
}
