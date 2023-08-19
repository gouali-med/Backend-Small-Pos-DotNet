namespace GestionCommercialeServices.Models.Repositories
{
    public interface IDbContextApp<TEntity>
    {
        Task<IList<TEntity>> List();
        Task<TEntity> Find(int id);
        Task Add(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
        Task<List<TEntity>> Search(string term);
            
    }
}
