using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.Repositories;

public class AirlineRepository : IAirlineDAL
{
    private DBContexts _dbContexts;

    public AirlineRepository(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task Insert(Airline airline)
    {
        await _dbContexts.Airlines.AddAsync(airline);
    }

    public async Task<string?> SelectContinentOfAirline(int id)
    {
        return await _dbContexts.Airlines.Where(a => a.Id == id).Select(a => a.Country.Continent.Name).SingleOrDefaultAsync();
    }

    public async Task<int> SelectAirplaneCompany(int id)
    {
        return await _dbContexts.Airplanes.Where(a => a.Id == id).Select(c => c.Company.Id).SingleOrDefaultAsync();
    }

    public async Task<int> CountOfPlane(int id)
    {
        return await _dbContexts.Lineplanes.Where(l => l.Airline.Id == id).CountAsync();
    }

    public async Task<bool> SelectRegisterationNumber(string registrationNumber)
    {
        return await _dbContexts.Lineplanes.AnyAsync(l => l.RegistrationNumber == registrationNumber);
    }

    public async Task InsertAirplaneOfAirline(LinePlane linePlane)
    {
        await _dbContexts.Lineplanes.AddAsync(linePlane);
    }

    public async Task<Airline?> GetAirline(int id)
    {
        return await _dbContexts.Airlines.SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task<LinePlane?> GetLinePlane(int id)
    {
        return await _dbContexts.Lineplanes.SingleOrDefaultAsync(l => l.Id == id);
    }
}