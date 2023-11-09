using PRN221_Project.Models;

namespace PRN221_Project.Services.IService
{
    public interface IProductCategoryService
    {
        public List<ProductCategory> GetAllCategory();
        public void AddCategory(ProductCategory category);
        
        public ProductCategory GetCategoryById(int ?id);

        public void UpdateCategory(ProductCategory category);

        public ProductCategory GetCategoryByName(string name);
      
    }
}
