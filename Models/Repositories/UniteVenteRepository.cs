using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class UniteVenteRepository: IDbContextApp<UniteOfSale>
    {
        AppDbContext db;
        public UniteVenteRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(UniteOfSale entity)
        {
            db.UniteOfSales.Add(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var UniteVente =await Find(id);

            db.UniteOfSales.Remove(UniteVente);
            await db.SaveChangesAsync();
        }


        public async Task< UniteOfSale> Find(int id)
        {
            var UniteVente =await db.UniteOfSales.SingleOrDefaultAsync(b => b.ID == id);

            return UniteVente;
        }

        public async Task< IList<UniteOfSale>> List()
        {
            return await db.UniteOfSales.ToListAsync();
        }

        public async Task Update(int id, UniteOfSale newUniteVente)
        {
            db.Update(newUniteVente);
            db.SaveChanges();
        }

        public async Task< List<UniteOfSale>> Search(string term)
        {
            var result = await db.UniteOfSales
                .Where(b => b.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}