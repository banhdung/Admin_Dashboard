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
    public class IndexModel : PageModel
    {
      
        private IProductCategoryService productCategoryService;

        public IndexModel( IProductCategoryService productCategoryService)
        {       
            this.productCategoryService = productCategoryService;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
                
                ProductCategory =  productCategoryService.GetAllCategory();
        }
    }
}
