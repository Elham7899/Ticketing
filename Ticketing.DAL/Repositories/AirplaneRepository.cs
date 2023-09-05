using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.Repositories;

public class AirplaneRepository : IAirplaneDAL
{
    private DBContexts _dbContexts;

    public AirplaneRepository(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task Insert(Airplane airplane)
    {
        await _dbContexts.Airplanes.AddAsync(airplane);
    }

    public async Task<Airplane?> GetAirplane(int Id)
    {
        return await _dbContexts.Airplanes.SingleOrDefaultAsync(a => a.Id == Id);
    }
    public async Task<List<Airplane>> SelectAirplaneOfAirline(int id)
    {
        return await _dbContexts.Lineplanes.Where(l => l.Airline.Id == id).Include(l => l.Airplane.Company).Select(l => l.Airplane).ToListAsync();
    }
}
