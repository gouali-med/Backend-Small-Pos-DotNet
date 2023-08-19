using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class DetailsSaleRepository : IDbContextApp<DetailsSale>
    {
        AppDbContext db;
        public DetailsSaleRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(DetailsSale entity)
        {
            db.DetailsSales.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Vente = await Find(id);

            db.DetailsSales.Remove(Vente);
            await db.SaveChangesAsync();

        }


        public async Task<DetailsSale> Find(int id)
        {
            var Vente = await db.DetailsSales.SingleOrDefaultAsync(b => b.ID == id);

            return Vente;
        }

        public async Task<IList<DetailsSale>> List()
        {
            return await db.DetailsSales.ToListAsync();
        }

        public async Task Update(int id, DetailsSale newdetails)
        {
            db.Update(newdetails);
            await db.SaveChangesAsync();
        }

        public async Task<List<DetailsSale>> Search(string term)
        {
            var result = await db.DetailsSales
                .Where(b => b.Product.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}
