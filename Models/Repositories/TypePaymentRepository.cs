using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class TypePaymentRepository : IDbContextApp<TypePayment>
    {
        AppDbContext db;
        public TypePaymentRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(TypePayment entity)
        {
            db.TypePayment.Add(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var TypePayment = await Find(id);

            db.TypePayment.Remove(TypePayment);
            await db.SaveChangesAsync();
        }


        public async Task< TypePayment> Find(int id)
        {
            var TypePayment =await db.TypePayment.SingleOrDefaultAsync(b => b.ID == id);

            return TypePayment;
        }

        public async Task< IList<TypePayment>> List()
        {
            return await db.TypePayment.ToListAsync();
        }

        public async Task Update(int id, TypePayment newTypePayment)
        {
            db.Update(newTypePayment);
           await db.SaveChangesAsync();
        }

        public async Task< List<TypePayment>> Search(string term)
        {
            var result =await db.TypePayment
                .Where(b => b.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}