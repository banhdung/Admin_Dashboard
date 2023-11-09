using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Admin.Categories
{
    public class DetailsModel : PageModel
    {

        private IProductCategoryService productCategoryService;

        public DetailsModel(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public ProductCategory ProductCategory { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null  )
            {
                return NotFound();
            }

            ProductCategory = productCategoryService.GetCategoryById(id);
            
            return Page();
        }
    }
}
