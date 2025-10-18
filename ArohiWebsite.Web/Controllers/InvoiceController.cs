using Microsoft.AspNetCore.Mvc;
using ArohiWebsite.Web.Models;

namespace ArohiWebsite.Web.Controllers
{
    [Route("mvc/invoice")]
    public class InvoiceController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var vm = new InvoiceViewModel();
            return View("Invoice", vm);
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(InvoiceViewModel model)
        {
            if (model.Products != null)
            {
                foreach (var p in model.Products)
                {
                    p.Amount = p.Quantity * p.Price;
                }
            }

            model.RecalculateTotal();

            // Server-side validation: require at least one product
            if (model.Products == null || model.Products.Count == 0)
            {
                ModelState.AddModelError("Products", "Please add at least one product before saving the invoice.");
            }

            if (!ModelState.IsValid)
            {
                return View("Invoice", model);
            }

            // TODO: persist invoice
            model.ShowSummary = true;
            return View("Invoice", model);
        }
    }
}