using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.Repositories;

public class CompanyRepository : ICompanyDAL
{
    private readonly DBContexts _dbContexts;

    public CompanyRepository(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task<Company?> Get(int Id)
    {
        return await _dbContexts.Companies.SingleOrDefaultAsync(c => c.Id == Id);
    }
}
