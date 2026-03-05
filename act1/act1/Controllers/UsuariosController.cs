using act1.Data;
using act1.Models;
using act1.Models.ViewModels;
using act1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace act1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .OrderBy(u => u.UsuarioId)
                .ToListAsync();

            return View(usuarios);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public async Task<IActionResult> Create()
        {
            await LoadRolesAsync();
            return View(new UsuarioCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadRolesAsync();
                return View(model);
            }

            bool usernameExists = await _context.Usuarios.AnyAsync(u => u.Username == model.Username);
            if (usernameExists)
            {
                ModelState.AddModelError(nameof(model.Username), "El usuario ya existe.");
                await LoadRolesAsync();
                return View(model);
            }

            var usuario = new Usuario
            {
                Username = model.Username,
                Email = model.Email,
                RolId = model.RolId,
                Activo = model.Activo,
                PasswordHash = PasswordHasher.HashPassword(model.Password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await LoadRolesAsync();

            var model = new UsuarioEditViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Username = usuario.Username,
                Email = usuario.Email,
                RolId = usuario.RolId,
                Activo = usuario.Activo
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioEditViewModel model)
        {
            if (id != model.UsuarioId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadRolesAsync();
                return View(model);
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            bool usernameExists = await _context.Usuarios.AnyAsync(u => u.Username == model.Username && u.UsuarioId != id);
            if (usernameExists)
            {
                ModelState.AddModelError(nameof(model.Username), "El usuario ya existe.");
                await LoadRolesAsync();
                return View(model);
            }

            usuario.Username = model.Username;
            usuario.Email = model.Email;
            usuario.RolId = model.RolId;
            usuario.Activo = model.Activo;

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                usuario.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadRolesAsync()
        {
            var roles = await _context.Roles
                .OrderBy(r => r.Nombre)
                .ToListAsync();

            ViewData["RolId"] = new SelectList(roles, nameof(Rol.RolId), nameof(Rol.Nombre));
        }
    }
}
