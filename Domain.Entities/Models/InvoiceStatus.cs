using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    /// <summary>
    /// Ricardo Martinez.
    /// Model Invoice Status references to the table InvoiceStatus
    /// are the kind of Invoice status
    /// </summary>
    public class InvoiceStatus
    {
        /// <summary>
        /// Primary key of the table
        /// </summary>
        [Key]
        public int Id { set; get; }
        /// <summary>
        /// Name of the InvoiceStatus
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { set; get; }
        /// <summary>
        /// Invoice status 0: Disabled , 1: Enable
        /// </summary>
        [Required]
        public bool Status { set; get; }

        public List<Transaction> transactions { get; } = new List<Transaction>();
    }
}
