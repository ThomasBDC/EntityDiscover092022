using EntityDiscover092022.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EntityDiscover092022.Controllers
{
    public class VoituresController : Controller
    {
        private readonly UserDbContext _context;

        public VoituresController(UserDbContext context)
        {
            //J'ai injecté le cUserDbContext dans mon contrôleur

            //Je le mets dans la propriété UserDbContext
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lstVoitures = await _context.Voitures.ToListAsync();
            return View(lstVoitures);
        }

        public async Task<IActionResult> Detail(int idVoiture)
        {
            var voiture = await _context.Voitures.FindAsync(idVoiture);

            return View(voiture);
        }
    }
}
