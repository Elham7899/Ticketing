using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Contract.Contract;

public interface IAirlineDAL
{
    Task Insert(Airline airline);
    Task<string?> SelectContinentOfAirline(int id);
    Task<int> SelectAirplaneCompany(int id);
    Task<int> CountOfPlane(int id);
    Task<bool> SelectRegisterationNumber(string registrationNumber);
    Task InsertAirplaneOfAirline(LinePlane linePlane);
    Task<Airline?> GetAirline(int id);
    Task<LinePlane?> GetLinePlane(int id);       
}
