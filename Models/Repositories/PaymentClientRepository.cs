using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class PaymentClientRepository: IDbContextApp<PaymentClient>
    {
        AppDbContext db;
        public PaymentClientRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(PaymentClient entity)
        {
          await  db.PaymentClients.AddAsync(entity);
           await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var PaymentClient =await Find(id);

            db.PaymentClients.Remove(PaymentClient);
            await db.SaveChangesAsync();
        }


        public async Task< PaymentClient> Find(int id)
        {
            var PaymentClient =await db.PaymentClients.SingleOrDefaultAsync(b => b.ID == id);

            return PaymentClient;
        }

        public async Task< IList<PaymentClient>> List()
        {
            return await db.PaymentClients.ToListAsync();
        }

        public async Task Update(int id, PaymentClient newPaymentClient)
        {
            db.Update(newPaymentClient);
          await  db.SaveChangesAsync();
        }

        public async Task< List<PaymentClient>> Search(string term)
        {
            var result =await db.PaymentClients
                .Where(b => b.Vente.Client.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}