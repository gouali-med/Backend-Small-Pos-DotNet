using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class CompanyRepository : IDbContextApp<Company>
    {
        AppDbContext db;
        public CompanyRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Company entity)
        {
            db.Companies.Add(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Company =await Find(id);

            db.Companies.Remove(Company);
          await  db.SaveChangesAsync();
        }


        public  async Task< Company> Find(int id)
        {
            var Company =await db.Companies.SingleOrDefaultAsync(b => b.ID == id);

            return Company;
        }

        public async Task< IList<Company>> List()
        {
            return await db.Companies.ToListAsync();
        }

        public async Task Update(int id, Company newCompany)
        {
            db.Update(newCompany);
           await db.SaveChangesAsync();
        }

        public async Task< List<Company>> Search(string term)
        {
            var result =await db.Companies
                .Where(b => b.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}


