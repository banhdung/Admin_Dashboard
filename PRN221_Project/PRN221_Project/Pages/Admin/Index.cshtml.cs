using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using System.Data;

namespace PRN221_Project.Pages.Admin
{


    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;
        public IndexModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }
        public double daysRevenue { get; set; }
        public double monthsRevenue { get; set; }
        public List<Invoice> invoices { get; set; }
        public List<Invoice> recentInvoices { get; set; }

        public List<Customer> customers {get; set; }
        public List<Product> hotProduct { get; set; }   
        public double dayRevenue(DateTime day)
        {
            daysRevenue = 0;
            invoices = _context.Invoices.ToList();

            foreach (var invoice in invoices)
            {

                if (invoice.DateRecorded == day)
                {
                    daysRevenue += invoice.TotalAmount;
                }       
            }
            return daysRevenue;
        }

        

        public double monthRevenue(DateTime month)
        {
            monthsRevenue = 0;
            invoices = _context.Invoices.ToList();

            foreach (var invoice in invoices)
            {

                if (invoice.DateRecorded.Date.Month == month.Month)
                {
                    monthsRevenue += invoice.TotalAmount;
                }
            }
            return monthsRevenue;
        }
        public int BestProductsSold { get; set; }
        public int SecondProductsSold { get; set; }
        public int ThirdProductsSold { get; set; }
        public int FourthProductsSold { get; set; }
        public string BestSellingCategory { get; set; }
        public string SecondBestSellingCategory { get; set; }

        public string ThirdBestSellingCategory { get; set; }
        public string FourthBestSellingCategory { get; set; }

        public int TotalProductSold { get; set; }
        public int TodayProductSold { get; set; }
        public int OtherProductSold { get; set; }
        public string hotCategory(int top)
        {
            string topCategory = _context.Sales
            .Join(_context.Products, sale => sale.ProductId, product => product.ProductId, (sale, product) => new { Sale = sale, Product = product })
            .Join(_context.ProductCategories, saleProduct => saleProduct.Product.CategoryId, category => category.CategoryId, (saleProduct, category) => new { SaleProduct = saleProduct, Category = category })
            .GroupBy(x => x.Category.CategoryId)
            .OrderByDescending(x => x.Count())
            .Select(x => x.FirstOrDefault().Category.CategoryName).Skip(top).Take(1)
            .FirstOrDefault();
            return topCategory;
        }




        public int ProductSold(int CategoryId)
        {
            return _context.Sales
                .Join(_context.Products, sale => sale.ProductId, product => product.ProductId, (sale, product) => new { Sale = sale, Product = product })
                .Join(_context.ProductCategories, saleProduct => saleProduct.Product.CategoryId, category => category.CategoryId, (saleProduct, category) => new { SaleProduct = saleProduct, Category = category })
                .Where(x => x.Category.CategoryId == CategoryId)
                .Count();
        }
        public IActionResult OnGet()
        {
           
            BestSellingCategory = hotCategory(0);

            SecondBestSellingCategory = hotCategory(1);
            ThirdBestSellingCategory = hotCategory(2);
            FourthBestSellingCategory = hotCategory(3);

            BestProductsSold = ProductSold(_context.ProductCategories.FirstOrDefault(x => x.CategoryName == BestSellingCategory).CategoryId);
            SecondProductsSold = ProductSold(_context.ProductCategories.FirstOrDefault(x => x.CategoryName == SecondBestSellingCategory).CategoryId);
            ThirdProductsSold = ProductSold(_context.ProductCategories.FirstOrDefault(x => x.CategoryName == ThirdBestSellingCategory).CategoryId);
            FourthProductsSold = ProductSold(_context.ProductCategories.FirstOrDefault(x => x.CategoryName == FourthBestSellingCategory).CategoryId);

            TotalProductSold = _context.Sales.Count();
            OtherProductSold = TotalProductSold - (BestProductsSold + SecondProductsSold + ThirdProductsSold);
            TodayProductSold = _context.Sales.Include(x => x.Invoice).Where(x => x.Invoice.DateRecorded == DateTime.Today).Count();

            customers = _context.Customers.ToList();
            recentInvoices = _context.Invoices.Include(x =>x.Customer).OrderByDescending(x => x.DateRecorded).Take(5).ToList(); 
            string ?userCookie = Request.Cookies["Role"];
            if (userCookie.Equals("1"))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/login");
            }

        }
    }
}