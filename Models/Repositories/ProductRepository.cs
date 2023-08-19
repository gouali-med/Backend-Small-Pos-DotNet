using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class ProductRepository : IDbContextApp<Product>
    {
        AppDbContext db;
        public ProductRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Product entity)
        {
           await db.Products.AddAsync(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product =await Find(id);

            db.Products.Remove(product);
           await db.SaveChangesAsync();
        }


        public async Task< Product> Find(int id)
        {
            var book =await db.Products.Include(a => a.Category).SingleOrDefaultAsync(b =>b.ID == id);

            return book;
        }

        public async Task< IList<Product>> List()
        {
            return await db.Products.Include(a => a.Category).ToListAsync();
        }

        public async Task Update(int id, Product newProduct)
        {
            db.Update(newProduct);
            await db.SaveChangesAsync();
        }

        public async Task<List<Product>> Search(string term)
        {
            var result =await db.Products.Include(a => a.Category)
                .Where(b => b.Name.Contains(term)
                        || b.Category.Name.Contains(term)
                        || b.BarCode.Contains(term)).ToListAsync();

            return result;
        }
    }
}
