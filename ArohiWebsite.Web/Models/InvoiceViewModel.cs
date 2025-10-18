using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ArohiWebsite.Web.Models
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            InvoiceNumber = $"INV-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";
            InvoiceDate = DateTime.Now;
            Products = new List<ProductViewModel>();
            PaymentStatus = "Pending";
        }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10-digit mobile number")]
        public string CustomerMobile { get; set; } = string.Empty;

        public List<ProductViewModel> Products { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentStatus { get; set; }

        // Helper to compute total on server
        public void RecalculateTotal() => TotalAmount = Products?.Sum(p => p.Amount) ?? 0m;

        // flag for view rendering after save
        public bool ShowSummary { get; set; } = false;
    }

    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; } = 0.00m;

        public decimal Amount { get; set; }
    }
}