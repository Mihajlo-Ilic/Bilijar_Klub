using Get_Projekat.Models;
using Get_Projekat.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Get_Projekat.Hubs;

namespace Get_Projekat.Controllers
{
    [Authorize(Roles ="musterija")]
    public class Musterija : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<Korisnik> _mngKorisnika;
        private readonly SignInManager<Korisnik> _mngRegistrovanja;
        private readonly RoleManager<IdentityRole> _mngUloga;
        private readonly IHubContext<MojHub> hub;

        public Musterija(ApplicationDbContext db, UserManager<Korisnik> mngKorisnika, SignInManager<Korisnik> mngRegistrovanja, RoleManager<IdentityRole> mngUloga, IHubContext<MojHub> hub)
        {
            _db = db;
            _mngKorisnika = mngKorisnika;
            _mngRegistrovanja = mngRegistrovanja;
            _mngUloga = mngUloga;
            this.hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NovTermin()
        {
            ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovTermin(NovTermin m)
        {
            if (ModelState.IsValid)
            {
                var upit = (from termin in _db.termini
                            where termin.Date == m.Date && termin.StoId == m.StoId &&
                                ((termin.Start.CompareTo(m.End) < 0 && termin.End.CompareTo(m.End) >= 0)
                                || (termin.Start.CompareTo(m.Start) <= 0 && termin.End.CompareTo(m.Start) > 0)
                                )
                            select termin
                            );

                if (upit.Any())
                {
                    ModelState.AddModelError("", "Zauzet je tekuci termin");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }


                var user = await _mngKorisnika.FindByNameAsync(User.Identity.Name);

                var sto = _db.stolovi.Find(m.StoId);

                Termin t = new Termin {
                    StoId = m.StoId,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End,
                    UserId = user.Id,
                    Username = user.UserName
                };

                

                _db.termini.Add(t);

                _db.SaveChanges();


                PregledTermina pt = new PregledTermina
                {
                    StoId = m.StoId,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End,
                    UserId = user.Id,
                    Username = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    StoName = sto.Name,
                    TerminId = t.TerminId

                };


                await hub.Clients.All.SendAsync("NovTerminMusterija",pt);
                return RedirectToAction("Index");
            }
            ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
            return View();
        }

        public async Task<IActionResult> PregledLicnihTermina()
        {
            var us = await _mngKorisnika.FindByNameAsync(User.Identity.Name);
            var mod = (from user in _db.Users
                       join termin in _db.termini on user.Id equals termin.UserId
                       join s in _db.stolovi on termin.StoId equals s.StoId
                       where user.Id == us.Id
                       select new LicniTermini()
                       {
                           TerminId = termin.TerminId,
                           Name = user.Name,
                           Surname = user.Surname,
                           StoId = termin.StoId,
                           Date = termin.Date,
                           Start = termin.Start,
                           End = termin.End,
                           StoName = s.Name
                       }).ToList();

            return View(mod);
        }

        public async Task<IActionResult> brisiTermin(int id)
        {
            var res = _db.termini.Find(id);
            if (res == null)
            {
                return RedirectToAction("PregledLicnihTermina");
            }
            if (ModelState.IsValid)
            {
                _db.termini.Remove(res);
                _db.SaveChanges();

                
                await hub.Clients.All.SendAsync("IzbrisiTerminMusterija", id);
            }
            return RedirectToAction("PregledLicnihTermina");
        }

        public IActionResult izmeniTermin(int id)
        {
            var res = _db.termini.Find(id);
            ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> izmeniTermin(Termin m)
        {
            if (ModelState.IsValid)
            {
                var upit = (from termin in _db.termini
                            where termin.Date == m.Date && termin.StoId == m.StoId && m.TerminId!=termin.TerminId &&
                                ((termin.Start.CompareTo(m.End) < 0 && termin.End.CompareTo(m.End) >= 0)
                                || (termin.Start.CompareTo(m.Start) <= 0 && termin.End.CompareTo(m.Start) > 0)
                                )
                            select termin
                            );

                if (upit.Any())
                {
                    ModelState.AddModelError("", "Zauzet je tekuci termin");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }

                _db.termini.Update(m);
                _db.SaveChanges();

                var user = await _mngKorisnika.FindByNameAsync(User.Identity.Name);

                var sto = _db.stolovi.Find(m.StoId);

                PregledTermina pt = new PregledTermina
                {
                    StoId = m.StoId,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End,
                    UserId = user.Id,
                    Username = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    StoName = sto.Name,
                    TerminId = m.TerminId
                };

                await hub.Clients.All.SendAsync("IzmeniTerminMusterija", pt);
                return RedirectToAction("PregledLicnihTermina");
            }

            ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            await _mngRegistrovanja.SignOutAsync();
            return RedirectToAction("Login","Profil");

        }



    }
}
