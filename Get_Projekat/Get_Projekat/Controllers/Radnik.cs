using Get_Projekat.Models;
using Get_Projekat.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Get_Projekat.Hubs;

namespace Get_Projekat.Controllers
{
    [Authorize(Roles = "radnik")]
    public class Radnik : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<Korisnik> _mngKorisnika;
        private readonly SignInManager<Korisnik> _mngRegistrovanja;
        private readonly RoleManager<IdentityRole> _mngUloga;
        private readonly IHubContext<MojHub> hub;

        public Radnik(ApplicationDbContext db, UserManager<Korisnik> mngKorisnika, SignInManager<Korisnik> mngRegistrovanja, RoleManager<IdentityRole> mngUloga, IHubContext<MojHub> hub)
        {
            _db = db;
            _mngKorisnika = mngKorisnika;
            _mngRegistrovanja = mngRegistrovanja;
            _mngUloga = mngUloga;
            this.hub = hub;
        }

        public List<SelectListItem> dropdownStolovi()
        {
            return new SelectList(_db.stolovi,"StoId","Name").ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PregledTermina()
        {
            var mod = (from user in _db.Users
                       join termin in _db.termini on user.Id equals termin.UserId
                       join s in _db.stolovi on termin.StoId equals s.StoId
                       select new PregledTermina()
                       {
                           TerminId = termin.TerminId,
                           Username = user.UserName,
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

        public async Task<IActionResult> BrisiTermin(int id)
        {
            var res =  _db.termini.Find(id);
            if (res == null)
            {
                return RedirectToAction("PregledTermina");
            }
            if (ModelState.IsValid)
            {
                _db.termini.Remove(res);
                _db.SaveChanges();
                await hub.Clients.All.SendAsync("IzbrisiTerminAdmin", id);
            }
            return RedirectToAction("PregledTermina");
        }

        public async Task<IActionResult> Logoff()
        {
            await _mngRegistrovanja.SignOutAsync();
            return RedirectToAction("Login", "Profil");

        }



        public IActionResult PregledStolova()
        {
            IEnumerable<Sto> sto_lista = _db.stolovi;
            return View(sto_lista);
        }

        public IActionResult PregledMusterija()
        {
            var korisnici = (from user in _db.Users
                             join userRole in _db.UserRoles on user.Id equals userRole.UserId
                             join role in _db.Roles on userRole.RoleId equals role.Id
                             select new KorisnikPregled()
                             {
                                 Id = user.Id,
                                 username = user.UserName,
                                 name = user.Name,
                                 surname = user.Surname,
                                 type = role.Name,
                                 hash = user.PasswordHash
                             }
                            ).ToList();

            return View(korisnici);
        }

        public IActionResult DodajKorisnika()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NapraviKorisnika(RegisterViewModel m)
        {
            if (!_mngUloga.RoleExistsAsync("radnik").GetAwaiter().GetResult())
            {
                await _mngUloga.CreateAsync(new IdentityRole("radnik"));
                await _mngUloga.CreateAsync(new IdentityRole("musterija"));
            }


            if (ModelState.IsValid)
            {
                Korisnik korisnik = new Korisnik
                {
                    UserName = m.Username,
                    Name = m.Name,
                    Surname = m.Surname

                };

                var res = await _mngKorisnika.CreateAsync(korisnik, m.Password);

                if (res.Succeeded)
                {
                    await _mngKorisnika.AddToRoleAsync(korisnik, m.type);
                    return RedirectToAction("PregledMusterija");
                }

                foreach (var er in res.Errors)
                    ModelState.AddModelError("", er.Description);

                return View("DodajKorisnika");
            }
            return View("DodajKorisnika");
        }


        public async Task<IActionResult> BrisiKorisnika(string id)
        {
            var res = await _mngKorisnika.FindByIdAsync(id);
            if (res == null)
            {
                return RedirectToAction("PregledMusterija");
            }
            if (ModelState.IsValid)
            {
                await _mngKorisnika.DeleteAsync(res);
                _db.SaveChanges();
            }
            return RedirectToAction("PregledMusterija");
        }

        public IActionResult DodajTermin()
        {
            ViewBag.stolovi = new SelectList(_db.stolovi,"StoId","Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajTermin(AdminNovTermin m)
        {
            if (ModelState.IsValid)
            {
                DateTime tek = DateTime.Now;
                DateTime d = DateTime.Parse(m.Date+" "+m.Start);

                if (d < tek)
                {
                    ModelState.AddModelError("", "Datum je prosao");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }

                if (m.End.CompareTo(m.Start) <= 0)
                {
                    ModelState.AddModelError("", "Krajnji termin mora biti ispred pocetnog");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }

                if (m.End.CompareTo(m.Start)<=0)
                {
                    ModelState.AddModelError("", "Krajnji termin mora biti ispred pocetnog");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }


                var r = await _mngKorisnika.FindByNameAsync(m.Username);
                if (r == null)
                {
                    ModelState.AddModelError("","Ne postoji dati username");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }


                var upit = (from termin in _db.termini
                            where  termin.Date == m.Date && termin.StoId == m.StoId &&
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

                var sto = _db.stolovi.Find(m.StoId);

                Termin t = new Termin
                {
                    StoId = m.StoId,
                    UserId = r.Id,
                    Username = m.Username,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End
                };

                _db.termini.Add(t);

                _db.SaveChanges();

                LicniTermini lt = new LicniTermini
                {
                    TerminId = t.TerminId,
                    StoId = m.StoId,
                    StoName = sto.Name,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End
                };
                
                await hub.Clients.All.SendAsync("NovTerminAdmin", lt);

            }
            return RedirectToAction("PregledTermina");
        }

        [HttpGet]
        public IActionResult DodajSto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NapraviSto(Sto sto)
        {
            if (ModelState.IsValid)
            {
                _db.stolovi.Add(sto);
                _db.SaveChanges();
                return RedirectToAction("PregledStolova");
            }

            return View(sto);
        }

        public async Task<IActionResult> BrisiSto(int id)
        {
            IEnumerable<Sto> sto_lista = _db.stolovi;
            var obj = _db.stolovi.Find(id);
            if(obj == null)
            {
                return RedirectToAction("PregledStolova");
            }
            if (ModelState.IsValid)
            {
                _db.stolovi.Remove(obj);
                _db.SaveChanges();

                
            }
            return RedirectToAction("PregledStolova");
        }

        public IActionResult izmeniKorisnika(IzmeniKorisnika k)
        {
            return View(k);
        }

        public IActionResult izmeniTermin(int id)
        {
            var term = _db.termini.Find(id);

            if (term == null)
                return NotFound();

            ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");

            return View(term);
        }

        [HttpPost]
        public async Task<IActionResult> izmeniTermin(Termin m)
        {

            if (ModelState.IsValid)
            {

                var r = await _mngKorisnika.FindByNameAsync(m.Username);
                if (r == null)
                {
                    ModelState.AddModelError("", "Ne postoji dati username");
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    return View();
                }

                var upit = (from termin in _db.termini
                            where termin.Date == m.Date && termin.StoId == m.StoId && m.TerminId != termin.TerminId &&
                                ((termin.Start.CompareTo(m.End) < 0 && termin.End.CompareTo(m.End) >= 0)
                                || (termin.Start.CompareTo(m.Start) <= 0 && termin.End.CompareTo(m.Start) > 0)
                                )
                            select termin
                            );

                if (upit.Any())
                {
                    ViewBag.stolovi = new SelectList(_db.stolovi, "StoId", "Name");
                    ModelState.AddModelError("", "Zauzet je termin");
                    return View();
                }

                _db.termini.Update(m);
                _db.SaveChanges();

                var sto = _db.stolovi.Find(m.StoId);

                LicniTermini lt = new LicniTermini
                {
                    TerminId = m.TerminId,
                    Date = m.Date,
                    Start = m.Start,
                    End = m.End,
                    StoId = m.StoId,
                    StoName = sto.Name
                };

                await hub.Clients.All.SendAsync("IzmeniTerminAdmin", lt);

            }
            return View("izmeniKorisnika");
        }

        public IActionResult dugme_izmeniK(string id)
        {
            var obj = _mngKorisnika.FindByIdAsync(id).Result;
            if (obj == null)
                return NotFound();


            return RedirectToAction("izmeniKorisnika", new IzmeniKorisnika
            {
                Username = obj.UserName,
                Name = obj.Name,
                Surname = obj.Surname,
                Password = "",
                Id = obj.Id      
            });
        }

        [HttpPost]
        public async Task<IActionResult> izmeni_KorisnikaAsync(IzmeniKorisnika k)
        {
            var res = _mngKorisnika.FindByIdAsync(k.Id).Result;
            if(res == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                res.UserName = k.Username;
                res.Name = k.Name;
                res.Surname = k.Surname;

                if(k.Password != "" && k.Password != null)
                {
                   res.PasswordHash = _mngKorisnika.PasswordHasher.HashPassword(res,k.Password);
                }

                 var r = await _mngKorisnika.UpdateAsync(res);

                if (!r.Succeeded)
                    return NotFound();

                _db.SaveChanges();
                return RedirectToAction("PregledMusterija");
            }
            return RedirectToAction("PregledMusterija");
        }

        public IActionResult dugme_izmeni(int id)
        {
            var obj = _db.stolovi.Find(id);
            if (obj == null)
                return NotFound();
            return RedirectToAction("IzmeniSto",obj);
        }


        public IActionResult IzmeniSto(Sto sto)
        {
            return View(sto);
        }

        [HttpPost]
        public IActionResult izmeni_sto(Sto sto)
        {
            if (ModelState.IsValid)
            {
                _db.stolovi.Update(sto);
                _db.SaveChanges();
                return RedirectToAction("PregledStolova");
            }
            return View("IzmeniSto",sto);
        }

    }
}
