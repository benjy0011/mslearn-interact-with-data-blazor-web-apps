using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazingPizza.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpecialsController : Controller
    {
        private readonly ILogger<SpecialsController> _logger;
        private readonly PizzaStoreContext _db;

        public SpecialsController(ILogger<SpecialsController> logger, PizzaStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
        }
    }
}