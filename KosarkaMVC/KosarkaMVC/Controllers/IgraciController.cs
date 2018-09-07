using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KosarkaMVC.Interfaces;
using KosarkaMVC.Models;
using KosarkaMVC.Repository;

namespace KosarkaMVC.Controllers
{
    public class IgraciController : Controller
    {
        private IIgracRepository _igracRepository = new IgracRepository();
        private IEkipaRepository _ekipaRepository = new EkipaRepository();

        // GET: Igraci
        public ActionResult Index()
        {
            var igraci = _igracRepository.GetAll();
            return View(igraci.ToList());
        }

        // GET: Igraci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = _igracRepository.GetById(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // GET: Igraci/Create
        public ActionResult Create()
        {
            ViewBag.EkipaId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv");
            return View();
        }

        // POST: Igraci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Prezime,Visina,Tezina,Godiste,EkipaId")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                _igracRepository.Create(igrac);
                return RedirectToAction("Index");
            }

            ViewBag.EkipaId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", igrac.EkipaId);
            return View(igrac);
        }

        // GET: Igraci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = _igracRepository.GetById(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            ViewBag.EkipaId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", igrac.EkipaId);
            return View(igrac);
        }

        // POST: Igraci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Prezime,Visina,Tezina,Godiste,EkipaId")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                _igracRepository.Update(igrac);
                return RedirectToAction("Index");
            }
            ViewBag.EkipaId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", igrac.EkipaId);
            return View(igrac);
        }

        // GET: Igraci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = _igracRepository.GetById(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // POST: Igraci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igrac igrac = _igracRepository.GetById(id);
            _igracRepository.Delete(igrac);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _igracRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
