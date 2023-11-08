namespace NTT.Core.UnitOfWorks;
//IUnitOfWork design pattern, veritabanına yapılacak olan islemleri tek bir transaction uzerinden erismeye yarar.

public interface IUnitOfWork
{
    Task CommitAsync(); // SaveChangesAsync
    
    void Commit(); // SaveChanges
}