using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Controllers
{
  public class ProductsController : Controller
  {
    private readonly StoreContext _db;

    public ProductsController(StoreContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Product> model = _db.Products.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Product invoice)
    {
      _db.Products.Add(invoice);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisProduct = _db.Products
      .Include(product => product.JoinEntities)
      .ThenInclude(join => join.Invoice)
      .FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    public ActionResult Edit(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(invoice => invoice.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost]
    public ActionResult Edit(Product invoice)
    {
      _db.Entry(invoice).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(invoice => invoice.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(invoice => invoice.ProductId == id);
      _db.Products.Remove(thisProduct);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}