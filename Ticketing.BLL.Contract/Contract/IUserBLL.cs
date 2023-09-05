using Ticketing.BLL.Contract.Results;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;

namespace Ticketing.BLL.Contract.Contract;

public interface IUserBLL
{
    Task<Result> RegisterUser(UserDTO userDTO);

    Task<Result> UpdateUser(int id, UserDTO userDTO);

	Task<Result<User>> GetUser(int id);

	Task<Result> DeleteUser(int id);
}
