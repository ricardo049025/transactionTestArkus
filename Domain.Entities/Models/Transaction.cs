using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    /// <summary>
    /// Ricardo Martinez.
    /// Reference to the table Transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Primary key of the table
        /// </summary>
        [Key]
        public int Id { set; get; }
        /// <summary>
        /// Transaction's Date
        /// </summary>
        [Required]
        public DateTime Date { set; get; }
        /// <summary>
        /// Transaction's Amount
        /// </summary>
        [Required]
        public decimal Amount { set; get; }
        /// <summary>
        /// Transaction's Description
        /// </summary>
        [StringLength(200)]
        public string Description { set; get; }
        /// <summary>
        /// Key references to Invoice Status table
        /// </summary>
        public int InvoiceStatusId { set; get; }
        [ForeignKey("InvoiceStatusId")]
        public virtual InvoiceStatus InvoiceStatus { set; get; }
        public List<Invoice> invoices  { get; } = new List<Invoice>();
    }
}
