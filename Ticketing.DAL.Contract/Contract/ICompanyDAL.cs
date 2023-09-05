using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Contract.Contract;

public interface ICompanyDAL
{
    Task<Company?> Get(int Id);
}
