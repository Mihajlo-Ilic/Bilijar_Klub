using Get_Projekat.Hubs;
using Get_Projekat.Models;
using Get_Projekat.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Get_Projekat.Controllers
{
    
    public class Profil : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<Korisnik> _mngKorisnika;
        private readonly SignInManager<Korisnik> _mngRegistrovanja;
        private readonly RoleManager<IdentityRole> _mngUloga;
        private readonly IHubContext<MojHub> hub;

        public Profil(ApplicationDbContext db, UserManager<Korisnik> mngKorisnika, SignInManager<Korisnik> mngRegistrovanja, RoleManager<IdentityRole> mngUloga, IHubContext<MojHub> hub)
        {
            _db = db;
            _mngKorisnika = mngKorisnika;
            _mngRegistrovanja = mngRegistrovanja;
            _mngUloga = mngUloga;
            this.hub = hub;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel m)
        {
            if (ModelState.IsValid)
            {
                var res = await _mngRegistrovanja.PasswordSignInAsync(m.username, m.password, m.rememberMe,false);
                
                if (res.Succeeded)
                {
                    ApplicationDbContext.LogedUsername = String.Copy(m.username);

                    var us = await _mngKorisnika.FindByNameAsync(m.username);
                    if (await _mngKorisnika.IsInRoleAsync(us, "radnik"))
                    {
                        await hub.Groups.AddToGroupAsync(ControllerContext.HttpContext.Connection.Id,"radnik");
                        return RedirectToAction("Index", "Radnik");
                    }
                    else
                    {
                        await hub.Groups.AddToGroupAsync(ControllerContext.HttpContext.Connection.Id, "musterija");
                        return RedirectToAction("Index", "Musterija");
                    }
                }
                
            }
            ModelState.AddModelError("", "Greska pri logovanju!");
            return View();
        }

        public async Task<IActionResult> Register()
        {
            if (!_mngUloga.RoleExistsAsync("radnik").GetAwaiter().GetResult())
            {
                await _mngUloga.CreateAsync(new IdentityRole("radnik"));
                await _mngUloga.CreateAsync(new IdentityRole("musterija"));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel m)
        {
            if (ModelState.IsValid)
            {
                Korisnik korisnik = new Korisnik
                {
                    UserName = m.Username,
                    Name = m.Name,
                    Surname = m.Surname

                };

                var res = await _mngKorisnika.CreateAsync(korisnik,m.Password);

                if (res.Succeeded)
                {
                    await _mngKorisnika.AddToRoleAsync(korisnik,"musterija");
                    await _mngRegistrovanja.SignInAsync(korisnik,isPersistent:false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var er in res.Errors)
                    ModelState.AddModelError("", er.Description);
            }
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _mngRegistrovanja.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
