using GestionCommercialeServices.Models.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class CategoryRepository : IDbContextApp<Category>
    {
        AppDbContext db;
        public CategoryRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Category entity)
        {
          await  db.Categories.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Category =await Find(id);

            db.Categories.Remove(Category);
          await db.SaveChangesAsync();
        }


        public async Task< Category> Find(int id)
        {
            var Category =await db.Categories.SingleOrDefaultAsync(b => b.ID == id);

            return Category;
        }

        public async Task< IList<Category>> List()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task Update(int id, Category newCategory)
        {
            db.Update(newCategory);
           await db.SaveChangesAsync();
        }

        public async Task< List<Category>> Search(string term)
        {
            var result =await db.Categories
                .Where(b => b.Name.Contains(term)).ToListAsync();

            return result;
        }


    }
}
