using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models.Base;

namespace txs_hub_api.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // GET All
        Task<List<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAllAsQueryable();

        // GET By Id
        TEntity FindById(object id);
        
        Task<TEntity> FindByIdAsync(object id);

        // Create
        TEntity Create(TEntity entity);
        
        Task<TEntity> CreateAsync(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Update
        TEntity Update(TEntity entity);

        TEntity PartiallyUpdate(Guid id, JsonPatchDocument<TEntity> entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        // Delete
        void Delete(TEntity entity);

        TEntity? DeleteById(Guid entityId);

        void DeleteRange(IEnumerable<TEntity> entities);

        // Save
        bool Save();

        Task<bool> SaveAsync();
    }
}
