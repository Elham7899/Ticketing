using Microsoft.AspNetCore.Mvc;
using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Services;
using Ticketing.DTOModels.Models;

namespace Ticketing.Host.Controllers
{
    [ApiController]
    public class UserInformationsController : Controller
    {
        private readonly IInformationBLL _informationBLL;

        public UserInformationsController(IInformationBLL informationBLL)
        {
            _informationBLL = informationBLL;
        }

        [Route("api/users/{id}/contactinformation")]
        [HttpPost]
        public async Task<IActionResult> Post(int Id, List<InformationDTO> information)
        {
            var Result = await _informationBLL.Register(Id, information);

            return Ok(Result);
        }
    }
}
