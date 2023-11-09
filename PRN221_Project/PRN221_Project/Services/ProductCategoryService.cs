using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

using PRN221_Project.Services.IService;

namespace PRN221_Project.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private POSTContext _context;
        public ProductCategoryService(POSTContext context)
        {
            _context = context;
        }

        public void AddCategory(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            _context.SaveChanges(); 
        }

        public List<ProductCategory> GetAllCategory()
        {
            return _context.ProductCategories.ToList();
        }

        public  ProductCategory GetCategoryById(int ?id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.CategoryId == id);
            
            
        }

        public ProductCategory GetCategoryByName(string name)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.CategoryName == name);
        }

        public void UpdateCategory(ProductCategory category)
        {
            ProductCategory p = _context.ProductCategories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if(p != null) {
                _context.ProductCategories.Update(category);
                _context.SaveChanges();
            }
        }
    }
}
