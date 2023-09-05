using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Contract.Contract;

public interface IUserDAL
{
    Task<User?> Select(int Id);
    Task<int> Insert(User user);
    Task<bool> UserIsExist(string userName);
    Task<User?> GetUser(int id);
    void Delete(int Id);
    Task<int> GetInfo(int id);
}
