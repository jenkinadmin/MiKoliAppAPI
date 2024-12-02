using MiKoliAPI.Models;
using MiKoliAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace MiKoliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainController : ControllerBase
    {
        private readonly ContainService _containService;

        public ContainController()
        {
            _containService = new ContainService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contains>> GetContainbyId(int mainMenuID,int parameterId)
        {
            return Ok(_containService.GetContainById(mainMenuID,parameterId));
        }


    }

}
