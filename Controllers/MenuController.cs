using MiKoliAPI.Models;
using MiKoliAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace MiKoliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MainMenuService _mainmenuService;

        public MenuController()
        {
            _mainmenuService = new MainMenuService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<MainMenu>> Get()
        {
            return Ok(_mainmenuService.GetAllMenus());
        }

       
    }

}
