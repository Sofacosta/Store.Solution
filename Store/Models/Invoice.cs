using System.Collections.Generic;

namespace Store.Models
{
   public class Invoice
    {
        public Invoice()
        {
            this.JoinEntities = new HashSet<ProductInvoice>();
        }

        public int InvoiceId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductInvoice> JoinEntities { get;}
    }
}