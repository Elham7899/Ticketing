using Microsoft.AspNetCore.Mvc;
using Ticketing.BLL.Contract.Contract;
using Ticketing.DTOModels.Models;

namespace Ticketing.Host.Controllers;

[ApiController]
public class AirplanesController : Controller
{
    private readonly IAirplaneBLL _airplaneBLL;

    public AirplanesController(IAirplaneBLL airplaneBLL)
    {
        _airplaneBLL = airplaneBLL;
    }

    [Route("api/airplanes")]
    [HttpPost]
    public async Task<IActionResult> Post(AirplaneDTO airplaneDTO)
    {
        await _airplaneBLL.SetAirPlaneModel(airplaneDTO);

        return Ok();
    }
}
