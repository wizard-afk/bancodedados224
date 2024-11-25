using Microsoft.AspNetCore.Mvc;
using CampeonatoOrganizado.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoOrganizado.Controllers
{
    public class AtletasController : Controller
    {
        private readonly BancoDadosContext _context;

        public AtletasController(BancoDadosContext context)
        {
            _context = context;
        }

         public IActionResult Index()
        {
            var Atletas = _context.Atletas.ToList();
            return View(Atletas);
        }
    }
}
