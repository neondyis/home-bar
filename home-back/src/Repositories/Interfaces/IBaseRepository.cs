using System.Linq.Expressions;

namespace src.Repositories.Interfaces;

public interface IBaseRepository <T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    Task Add(T entity);
    Task Put(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
