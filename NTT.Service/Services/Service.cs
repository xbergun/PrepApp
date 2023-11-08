using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;

namespace NTT.Service.Services;

// Repository ile haberleşerek, veritabanı işlemlerini yapar. Yani veritabanına, repository katmanında hazırlanan sorguyu gönderir.
public class Service<T> : IService<T> where T : class
{
    private IGenericRepository<T> Repository { get; }
    private IUnitOfWork UnitOfWork { get; }

    public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
    {
        Repository = repository;
        UnitOfWork = unitOfWork;
    }


    public async Task<T> GetByIdAsync(int id)
    {
       return await Repository.GetByIdAsync(id);
        
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Repository.GetAll().ToListAsync();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity)
    {
        await Repository.AddAsync(entity);
        await UnitOfWork.CommitAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        var addRangeAsync = entities as T[] ?? entities.ToArray();
        await Repository.AddRangeAsync(addRangeAsync);
        await UnitOfWork.CommitAsync();
        return addRangeAsync;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Repository.AnyAsync(expression);
    }

    public async Task Update(T entity)
    {
        Repository.Update(entity);
        await UnitOfWork.CommitAsync();
    }

    public async Task Remove(T entity)
    {
        Repository.Remove(entity);
        await UnitOfWork.CommitAsync();
    }

    public async Task RemoveRange(IEnumerable<T> entities)
    {
        Repository.RemoveRange(entities);
        await UnitOfWork.CommitAsync();
    }
}