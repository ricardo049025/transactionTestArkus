using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Payment
    {
        [Key]
        public int Id { set; get; }

        [ForeignKey("InvoiceId")]
        public int InvoiceId { set; get; }
        public Invoice Invoice { set; get; }
    }
}
