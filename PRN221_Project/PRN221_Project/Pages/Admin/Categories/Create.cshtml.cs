using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {

        private IProductCategoryService productCategoryService;
        public CreateModel(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;  
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid  || ProductCategory == null)
            {
                return Page();
            }
           if(productCategoryService.GetCategoryByName(ProductCategory.CategoryName)!= null)
            {
                TempData["error"] = "Category Name existed";
                return Redirect("/admin/categories/create");
            }
            productCategoryService.AddCategory(ProductCategory);
            TempData["success"] = "Create successfully";

            return RedirectToPage("./Index");
        }
    }
}
