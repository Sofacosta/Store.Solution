namespace Store.Models
{
  public class ProductInvoice
    {       
        public int ProductInvoiceId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}