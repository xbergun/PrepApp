using System.Linq.Expressions;

namespace NTT.Core.Repositories;

//Veritabanı işlemleri için implemente edilecek interface. Ancak veritabanına erişim sağlamaz.
public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    
    IQueryable<T> GetAll();
    
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    
    Task AddAsync(T entity);
    
    Task AddRangeAsync(IEnumerable<T> entities);
    
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    // Update, Delete gibi sorguların ASYNC metodu yoktur. Çünkü sadece state i değiştirir.
    void Update(T entity);
    
    void Remove(T entity);
    
    void RemoveRange(IEnumerable<T> entities);
}