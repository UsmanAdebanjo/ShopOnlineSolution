using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositiories.Contracts;

namespace ShopOnline.Api.Repositiories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _context;
        public ProductRepository(ShopOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            return await _context.Products.ToListAsync();

        }
        public async Task<Product> GetItem(int id)
        {
            //var item= await  _context.Products.FindAsync(id);
            var item = await _context.Products.SingleOrDefaultAsync(c => c.Id == id);

            return item;
        }



        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategory(int id)
        {
            //var productCategory=await _context.ProductCategories.FindAsync(id);
            var productCategory=await _context.ProductCategories.SingleOrDefaultAsync(p=>p.Id==id);
            return productCategory;

        }
    }
}
