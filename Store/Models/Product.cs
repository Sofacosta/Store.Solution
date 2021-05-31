using System.Collections.Generic;

namespace Store.Models
{
  public class Product
  {
    public Product()
    {
      this.Invoices = new HashSet<Invoice>();
    }

    public int ProductId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
  }
}
