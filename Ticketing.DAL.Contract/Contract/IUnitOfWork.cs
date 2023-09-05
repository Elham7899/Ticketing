namespace Ticketing.DAL.Contract.Contract;

public interface IUnitOfWork
{
    Task Comit();
}
