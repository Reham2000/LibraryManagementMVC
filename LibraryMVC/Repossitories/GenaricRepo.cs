using LibraryMVC.Data;
using LibraryMVC.Repossitories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryMVC.Repossitories
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {

        // DI
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>(); // _context.Books
        }
        public void Add(T entity)
        {
             _table.Add(entity);
            //return _context.SaveChanges() > 0;
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            //return _context.SaveChanges() > 0;
        }

        public bool Exists(Expression<Func<T, bool>> condation)
        {
            return _table.Any(condation);
        }

        public List<T> Find(Expression<Func<T, bool>> condation)
        {
            return _table.Where(condation).ToList();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }
        public List<T> GetAll(
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }
        public T? GetById(int id)
        {
            return _table.Find(id);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            //return _context.SaveChanges() > 0;
        }

    }
}
