using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class VenteRepository : IDbContextApp<Sale>
    {
        AppDbContext db;
        public VenteRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Sale entity)
        {
            db.Ventes.Add(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Vente =await Find(id);

            db.Ventes.Remove(Vente);
            await db.SaveChangesAsync();

        }


        public async Task< Sale> Find(int id)
        {
            var Vente =await db.Ventes.SingleOrDefaultAsync(b => b.ID == id);

            return Vente;
        }

        public async Task< IList<Sale>> List()
        {
            return await db.Ventes.ToListAsync();
        }

        public async Task Update(int id, Sale newVente)
        {
            db.Update(newVente);
           await db.SaveChangesAsync();
        }

        public async Task< List<Sale> > Search(string term)
        {
            var result = await db.Ventes
                .Where(b => b.Client.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}
