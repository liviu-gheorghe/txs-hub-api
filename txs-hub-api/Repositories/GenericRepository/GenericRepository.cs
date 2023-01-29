using txs_hub_api.Data;
using txs_hub_api.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace txs_hub_api.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var allItems = await _table.AsNoTracking().ToListAsync();
            return allItems;
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _table.AsQueryable();
        }

        // create
        public TEntity Create(TEntity entity)
        {
            _table.Add(entity);
            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            return entity;
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // update
        public TEntity Update(TEntity entity)
        {
            _table.Update(entity);
            return entity;
        }

        public TEntity PartiallyUpdate(Guid id, JsonPatchDocument<TEntity> entity)
        {
            var foundEntity = _table.Find(id);

            if(foundEntity == null)
            {
                Console.WriteLine("found entity is null");
                return foundEntity;
            } else
            {
                Console.WriteLine("found entity is not null");
            }
            entity.ApplyTo(foundEntity);
            _table.Update(foundEntity);
            return foundEntity;

        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // delete

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public TEntity? DeleteById(Guid entityId)
        {
            var entityToBeDeleted = _table.SingleOrDefault(x => x.Id.Equals(entityId));

            Console.WriteLine(entityId);
            Console.WriteLine(entityToBeDeleted);

            if (entityToBeDeleted != null)
            {
                _table.Remove(entityToBeDeleted);
                _context.SaveChanges();
            }

            return entityToBeDeleted;

        }

        // save

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
