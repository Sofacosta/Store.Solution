namespace Store.Models
{
  public class Invoice
  {
    public int InvoiceId { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
  }
}
