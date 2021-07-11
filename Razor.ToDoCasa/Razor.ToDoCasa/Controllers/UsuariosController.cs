using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.ToDoCasa.Domains;

namespace Razor.ToDoCasa.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly TodoCasaContext _context;

        public UsuariosController(TodoCasaContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // GET: Usuarios/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Senha")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Senha")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Usuarios.Any(e => e.Id == usuarios.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
