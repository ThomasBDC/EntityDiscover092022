using EntityDiscover092022.Models;
using EntityDiscover092022.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EntityDiscover092022.Controllers
{
    public class TachesController : Controller
    {
        private readonly UserDbContext _context;

        public TachesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: Taches
        public async Task<IActionResult> Index()
        {
            var toto = _context.Taches.ToList();

            //LINQ c'est une librairie de requête sur des listes
            //Syntaxe méthode
            var namewithU = toto.Where(tache =>
                tache.Nom.Contains("U") ||
                tache.Nom.Contains("u")).ToList();

            //Syntaxe requête
            var nameU = from tache in toto
                        where tache.Nom.Contains("U") || tache.Nom.Contains("u")
                        select tache;


            return View(await _context.Taches.ToListAsync());
        }

        // GET: Taches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taches = await _context.Taches
                .FirstOrDefaultAsync(m => m.TachesId == id);
            if (taches == null)
            {
                return NotFound();
            }

            return View(taches);
        }

        // GET: Taches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TachesId,Nom,Description,DateDebut,Status")] Taches taches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taches);
        }

        // GET: Taches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taches = await _context.Taches.FindAsync(id);
            if (taches == null)
            {
                return NotFound();
            }
            return View(taches);
        }

        // POST: Taches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TachesId,Nom,Description,DateDebut,Status")] Taches taches)
        {
            if (id != taches.TachesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TachesExists(taches.TachesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taches);
        }

        // GET: Taches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taches = await _context.Taches
                .FirstOrDefaultAsync(m => m.TachesId == id);
            if (taches == null)
            {
                return NotFound();
            }

            return View(taches);
        }

        // POST: Taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taches = await _context.Taches.FindAsync(id);
            _context.Taches.Remove(taches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TachesExists(int id)
        {
            return _context.Taches.Any(e => e.TachesId == id);
        }
    }
}
