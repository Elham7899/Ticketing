using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.Repositories;

public class CountryRepository : ICountryDAL
{
    private DBContexts _dbContexts;
    public CountryRepository(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task<Country?> GetCountry(int Id)
    {
        return await _dbContexts.Countries.SingleOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<List<Country>> Select()
    {
        return await _dbContexts.Countries.Select(c => c).ToListAsync();
    }
}
