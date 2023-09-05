using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Contract.Contract;

public interface ICountryDAL
{
    Task<Country?> GetCountry(int Id);
    Task<List<Country>> Select();
}
