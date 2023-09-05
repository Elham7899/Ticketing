using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.EFDBContexts;

namespace Ticketing.DAL.Repositories;

public class UserRepository : IUserDAL
{
    private DBContexts _dbContexts;

    public UserRepository(DBContexts dBContexts)
    {
        _dbContexts = dBContexts;
    }

    public async Task<User?> Select(int Id)
    {
        return await _dbContexts.Users.Where(u => u.Id == Id).Include(u => u.Nationality).Include(u => u.ContactInformation).SingleOrDefaultAsync();
    }

    public async Task<int> Insert(User user)
    {
        await _dbContexts.Users.AddAsync(user);

        return user.Id;
    }

    public async Task<bool> UserIsExist(string userName)
    {
        return await _dbContexts.Users.AnyAsync(u => u.UserName == userName);
    }

    public async Task<User?> GetUser(int id)
    {
        return await _dbContexts.Users.Where(u => u.Id == id).Include(u=>u.ContactInformation).SingleOrDefaultAsync();
    }

    public void Delete(int id)
    {
        _dbContexts.Remove(id);
    }
    
    public async Task<int> GetInfo(int id)
    {
        return await _dbContexts.Users.Where(u => u.Id == id).Include(u => u.ContactInformation).CountAsync();

	//	return await _dbContexts.Information.Where(u => u.User.Id==id).Select(i=>i.User.Id).CountAsync();
    }
}
