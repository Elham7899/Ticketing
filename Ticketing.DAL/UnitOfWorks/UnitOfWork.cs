using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.UnitOfWorks;

public class UnitOfWork:IUnitOfWork
{
    private readonly DBContexts _dbContexts;

    public UnitOfWork(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task Comit()
    {
        await _dbContexts.SaveChangesAsync();
    }
}
