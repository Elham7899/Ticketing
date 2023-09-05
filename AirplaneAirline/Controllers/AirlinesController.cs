using Microsoft.AspNetCore.Mvc;
using Ticketing.BLL.Contract.Contract;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.Host.Controllers;

[ApiController]
public class AirlinesController : Controller
{
    private readonly IAirlineBLL _airlineBLL;

    public AirlinesController(IAirlineBLL airlineBLL)
    {
        _airlineBLL = airlineBLL;
    }

    [Route("api/airlines/{id}/airplanes")]
    [HttpGet]
    public async Task<IActionResult> Get(int Id)
    {
        var result = await _airlineBLL.SelectAirplaneOfLine(Id);

        return Ok(result);
    }

    [Route("api/airlines")]
    [HttpPost]
    public async Task<IActionResult> Post(AirlineDTO airlineDTO)
    {
        await _airlineBLL.SetAirLineInfo(airlineDTO);

        return Ok();
    }

    [Route("api/airlines/{id}/airplanes")]
    [HttpPost]
    public async Task<IActionResult> Post(int Id, LinePlaneDTO linePlaneDTO)
    {
        var result = await _airlineBLL.SetAirPlanesOfAirLine(Id, linePlaneDTO);

        return BadRequest(result);
    }

    [Route("api/airlines/airplanes/{id}/airworthiness")]
    [HttpPut]
    public async Task<IActionResult> Put(int Id, Airworthiness airworthiness)
    {
        var Result = await _airlineBLL.ChangeAirworthiness(Id, airworthiness);

        return BadRequest(Result);
    }
}
