using System.Linq.Expressions;

namespace NTT.Core.Services;

//Business katmanında kullanılacak olan servislerin implemente edeceği interface.
// Repository interface'i ile aynı metotları içerir. Ancak burada veritabanı işlemleri değil, iş kuralları yazılır. Mapping yapabilirsiniz en kolay ornegi.

public interface IService <T> where T : class
{
    Task<T> GetByIdAsync(int id);
    
    Task<IEnumerable<T>> GetAllAsync();
    
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    
    Task<T> AddAsync(T entity);
    
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    // Veritabanına yansıtılacagi icin, ASYNC yapabiliriz.
    Task Update(T entity);
    
    Task Remove(T entity);
    
    Task RemoveRange(IEnumerable<T> entities);
}