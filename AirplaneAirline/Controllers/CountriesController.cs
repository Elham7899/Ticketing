using Microsoft.AspNetCore.Mvc;
using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Services;

namespace Ticketing.Host.Controllers;

[ApiController]
public class CountriesController : Controller
{
    private readonly ICountryBLL _countryBLL;

    public CountriesController(ICountryBLL countryBLL)
    {
        _countryBLL = countryBLL;
    }

    [Route("api/countries")]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_countryBLL);
    }
}
