﻿using KutseeApp_Grigorjev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KutseeApp_Grigorjev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string pidu = "";
            if (DateTime.Now.Month == 1) { pidu = "Jaanuari pidu"; }
            else if (DateTime.Now.Month == 2) { pidu = "Baarmeni päev pidu"; }
            else if (DateTime.Now.Month == 3) { pidu = "naistepäev pidu"; }
            else if (DateTime.Now.Month == 4) { pidu = "aprillinali pidu"; }
            else if (DateTime.Now.Month == 5) { pidu = "Võidupüha pidu"; }
            else if (DateTime.Now.Month == 6) { pidu = "Lastekaitsepäev"; }
            else if (DateTime.Now.Month == 7) { pidu = "Spordiajakirjaniku päev"; }
            else if (DateTime.Now.Month == 8) { pidu = "arbuusipäev"; }
            else if (DateTime.Now.Month == 9) { pidu = "Teadmiste päev"; }
            else if (DateTime.Now.Month == 10) { pidu = "Ülemaailmne loomade päev"; }
            else if (DateTime.Now.Month == 11) { pidu = "Ennustamispäev kohvipaksu peal"; }
            else if (DateTime.Now.Month == 12) { pidu = "vanaaasta õhtu"; }


            ViewBag.Message = "Ootan sind oma peole! " + pidu + " Palun tule kindlasti!";

            int hour = DateTime.Now.Hour;
            if (hour <= 16)
            {
                ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";
            }
            else if (hour > 16)
            {
                ViewBag.Greeting = hour < 20 ? "Tere õhtu" : "Tere päevast";
            }

            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                ViewBag.Greeting = guest.Email;
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
            return RedirectToAction("Guest");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guest");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Guest");
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminetthk2@gmail.com";
                WebMail.Password = "2.kuursus tarpv20";
                WebMail.From = "programmeeriminetthk2@gmail.com";
                WebMail.Send(guest.Email, "Vastus kutsele ", guest.Name + " vastas" + ((guest.WillAttend ?? false) ? " tuleb peole: " : " ei tule peole "));
                WebMail.Send(guest.Email, "Meeldetuletus", guest.Name + ", ara unusta. Pidu toimub 12.03.22! Sind ootavad väga!",
                    null, "aleksei.tiora@gmail.com");
                ViewBag.Message = "Kiri on saatnud";

            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju!Ei saa kirja saada!";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        GuestContext db = new GuestContext();
        [Authorize] //-Данное представление Guests сможет увидить только авторозированный пользователь
        public ActionResult Guest()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }
    }
}