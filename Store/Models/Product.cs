using System.Collections.Generic;

namespace Store.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinEntities = new HashSet<ProductInvoice>();
    }

    public int ProductId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProductInvoice> JoinEntities { get; set; }
  }
}
