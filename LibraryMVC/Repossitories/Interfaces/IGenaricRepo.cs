using System.Linq.Expressions;

namespace LibraryMVC.Repossitories.Interfaces
{
    public interface IGenaricRepo<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(
                Expression<Func<T,bool>> condation
            );
        List<T> Find(
                Expression<Func<T, bool>> condation
            );
        List<T> GetAll(
            params Expression<Func<T, object>>[] includes
            );
    }
}
