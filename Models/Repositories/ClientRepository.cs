using GestionCommercialeServices.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace GestionCommercialeServices.Models.Repositories
{
    public class ClientRepository: IDbContextApp<Client>
    {
        AppDbContext db;
        public ClientRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Client entity)
        {
            db.Clients.AddAsync(entity);
           await  db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Client =await Find(id);

            db.Clients.Remove(Client);
           await  db.SaveChangesAsync();
        }


        public async Task< Client> Find(int id)
        {
            var Client =await db.Clients.SingleOrDefaultAsync(b => b.ID == id);

            return Client;
        }

        public async Task< IList<Client>> List()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task Update(int id, Client newClient)
        {
            db.Update(newClient);
           await  db.SaveChangesAsync();
        }

        public async Task< List<Client>> Search(string term)
        {
            var result =await db.Clients
                .Where(b => b.Name.Contains(term)).ToListAsync();

            return result;
        }
    }
}


