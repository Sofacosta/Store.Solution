using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Controllers
{
  public class InvoicesController : Controller
  {
    private readonly StoreContext _db;

    public InvoicesController(StoreContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Invoices.ToList());
    }

//     public ActionResult Create()
//     {
//       ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Invoice invoice)
//     {
//       _db.Invoices.Add(invoice);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

    public ActionResult Details(int id)
    {
        var thisInvoice = _db.Invoices
            .Include(invoice => invoice.JoinEntities)
            .ThenInclude(join => join.Product)
            .FirstOrDefault(invoice => invoice.InvoiceId == id);
        return View(thisInvoice);
    }

//     public ActionResult Edit(int id)
//     {
//       var thisInvoice = _db.Invoices.FirstOrDefault(invoice => invoice.InvoiceId == id);
//       ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
//       return View(thisInvoice);
//     }

//     [HttpPost]
//     public ActionResult Edit(Invoice invoice)
//     {
//       _db.Entry(invoice).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisInvoice = _db.Invoices.FirstOrDefault(invoice => invoice.InvoiceId == id);
//       return View(thisInvoice);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisInvoice = _db.Invoices.FirstOrDefault(invoice => invoice.InvoiceId == id);
//       _db.Invoices.Remove(thisInvoice);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  }
}