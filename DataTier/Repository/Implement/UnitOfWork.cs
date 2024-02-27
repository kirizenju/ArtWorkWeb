using DataTier.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace DataTier.Repository.Implement
{
    public class UnitOfWork<TContext>: IUnitOfWork <TContext> where TContext : DbContext
    {

        private readonly TContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        //public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class 
        //{  
        //    _repositories = new Dictionary<Type, object>();
        //    if (_repositories.TryGetValue(typeof(TEntity), out object repository)) { 
        //        return (IGenericRepository<TEntity>)repository;
        //    }
        //    repository=new GenericRepository<TEntity>(Context);
        //    _repositories.Add(typeof(TEntity), repository);
        //    return GetRepository<TEntity>(); 
        //}
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);
            if (!_repositories.ContainsKey(entityType))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(entityType, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[entityType];
        }
        public void Dispose()
        {
            Context?.Dispose();
        }

        public int Commit()
        {
            TrackChanges();
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            TrackChanges();
            return await Context.SaveChangesAsync();
        }

        private void TrackChanges()
        {
            var validationErrors = Context.ChangeTracker.Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(e => e != ValidationResult.Success)
                .ToArray();
            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine,
                    validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
                throw new Exception(exceptionMessage);
            }
        }
    }
}
