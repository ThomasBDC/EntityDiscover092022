using EntityDiscover092022.Models;
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

        public async Task<IActionResult> Edit(int id)
        {
            //Faut récupérer la voiture que je veut modifier 
            var voiture = await _context.Voitures.FindAsync(id);

            //Pour pouvoir la donner à la vue
            return View(voiture);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Voiture voiture) 
        {
            //Je modifie la voiture dans mon context
            _context.Update(voiture);

            //Enregistrer en BDD
            await _context.SaveChangesAsync();

            //retourner sur la page des voitures
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Voiture voiture)
        {
            _context.Add(voiture); 
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var voiture = await _context.Voitures.FindAsync(id);

            return View(voiture);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);

            _context.Voitures.Remove(voiture);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
