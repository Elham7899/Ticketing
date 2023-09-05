using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Contract.Contract;

public interface IAirplaneDAL
{
    Task Insert(Airplane airplane);
    Task<Airplane?> GetAirplane(int Id);
    Task<List<Airplane>> SelectAirplaneOfAirline(int id);
}
