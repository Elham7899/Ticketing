using Microsoft.AspNetCore.Mvc;
using Ticketing.BLL.Contract.Contract;
using Ticketing.DTOModels.Models;

namespace Ticketing.Host.Controllers;

[ApiController]
public class UsersController : Controller
{
    private readonly IUserBLL _userBLL;

    public UsersController(IUserBLL userBLL)
    {
        _userBLL = userBLL;
    }

    [Route("api/users/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int Id)
    {
        var result = await _userBLL.GetUser(Id);

        return Ok(result);
    }

    [Route("api/users")]
    [HttpPost]
    public async Task<IActionResult> Post(UserDTO userDTO)
    {
        var result = await _userBLL.RegisterUser(userDTO);

        return Ok(result);
    }

    [Route("api/users/{id}")]
    [HttpPut]
    public async Task<IActionResult> Put(int Id, UserDTO userDTO)
    {
        var Result = await _userBLL.UpdateUser(Id, userDTO);

        return Ok(Result);
    }


    [Route("api/users/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int Id, UserDTO userDTO)
    {
        await _userBLL.UpdateUser(Id, userDTO);

        return Ok("1 row Deleted");
    }
}
