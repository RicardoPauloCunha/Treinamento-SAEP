using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.LanHouse.Contextos;
using Razor.LanHouse.Dominios;

namespace Razor.LanHouse.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly LanHouseContext _context;

        public UsuariosController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: RegistrosDefeitos/Create
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                Usuarios usuarioLogado = await _context.Usuarios
                    .Where(x => x.Email.ToLower() == usuario.Email.ToLower() && x.Senha.ToLower() == usuario.Senha.ToLower())
                    .FirstOrDefaultAsync();

                if (usuarioLogado == null)
                {
                    ViewBag.Mensagem = "Email ou senha inválidos. Tente novamente";
                    return View(usuario);
                }

                HttpContext.Session.SetString("email", usuarioLogado.Email);

                return RedirectToAction("index", "RegistrosDefeitos");
            }
            return View(usuario);
        }
    }
}
