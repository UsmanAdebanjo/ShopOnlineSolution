using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositiories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<Product> GetItem(int id);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        Task<ProductCategory> GetProductCategory(int id);   

    }
}
