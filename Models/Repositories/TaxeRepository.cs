using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class TaxeRepository : IDbContextApp<Taxe>
    {
        AppDbContext db;
        public TaxeRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Taxe entity)
        {
           await db.Taxes.AddAsync(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Taxe = await Find(id);

            db.Taxes.Remove(Taxe);
           await db.SaveChangesAsync();
        }


        public async Task<Taxe> Find(int id)
        {
            var Taxe =await db.Taxes.SingleOrDefaultAsync(b => b.ID == id);

            return Taxe;
        }


        public async  Task< IList<Taxe>> List()
        {
            return await db.Taxes.ToListAsync();
        }

        public async Task Update(int id, Taxe newTaxe)
        {
            db.Update(newTaxe);
           await db.SaveChangesAsync();
        }

        public async Task< List<Taxe>> Search(string term)
        {
            //var result = db.Taxes
            //    .Where(b => b.Valeur.Contains(term)).ToList();

            return null;
        }
    }
}