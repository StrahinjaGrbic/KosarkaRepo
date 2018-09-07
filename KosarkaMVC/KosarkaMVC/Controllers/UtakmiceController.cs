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
    public class UtakmiceController : Controller
    {
        private IUtakmicaRepository _utakmicaRepository = new UtakmicaRepository();
        private ISudijaRepository _sudijaRepository = new SudijaRepository();
        private IEkipaRepository _ekipaRepository = new EkipaRepository();

        // GET: Utakmice
        public ActionResult Index()
        {
            return View(_utakmicaRepository.GetAll());
        }

        // GET: Utakmice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = _utakmicaRepository.GetById(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            return View(utakmica);
        }

        // GET: Utakmice/Create
        public ActionResult Create()
        {
            ViewBag.EkipaAId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv");
            ViewBag.EkipaBId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv");
            ViewBag.Sudija1Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime");
            ViewBag.Sudija2Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime");
            ViewBag.Sudija3Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime");
            return View();
        }

        // POST: Utakmice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sezona,Kolo,Datum,EkipaAId,EkipaBId,Sudija1Id,Sudija2Id,Sudija3Id,RezultatA,RezultatB")] Utakmica utakmica)
        {
            if (ModelState.IsValid)
            {
                _utakmicaRepository.Create(utakmica);
                return RedirectToAction("Index");
            }

            ViewBag.EkipaAId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaAId);
            ViewBag.EkipaBId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaBId);
            ViewBag.Sudija1Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija1Id);
            ViewBag.Sudija2Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija2Id);
            ViewBag.Sudija3Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija3Id);
            return View(utakmica);
        }

        // GET: Utakmice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = _utakmicaRepository.GetById(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            ViewBag.EkipaAId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaAId);
            ViewBag.EkipaBId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaBId);
            ViewBag.Sudija1Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija1Id);
            ViewBag.Sudija2Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija2Id);
            ViewBag.Sudija3Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija3Id);
            return View(utakmica);
        }

        // POST: Utakmice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sezona,Kolo,Datum,EkipaAId,EkipaBId,Sudija1Id,Sudija2Id,Sudija3Id,RezultatA,RezultatB")] Utakmica utakmica)
        {
            if (ModelState.IsValid)
            {
                _utakmicaRepository.Update(utakmica);
                return RedirectToAction("Index");
            }
            ViewBag.EkipaAId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaAId);
            ViewBag.EkipaBId = new SelectList(_ekipaRepository.GetAll(), "Id", "Naziv", utakmica.EkipaBId);
            ViewBag.Sudija1Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija1Id);
            ViewBag.Sudija2Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija2Id);
            ViewBag.Sudija3Id = new SelectList(_sudijaRepository.GetAll(), "Id", "Ime", utakmica.Sudija3Id);
            return View(utakmica);
        }

        // GET: Utakmice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = _utakmicaRepository.GetById(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            return View(utakmica);
        }

        // POST: Utakmice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utakmica utakmica = _utakmicaRepository.GetById(id);
            _utakmicaRepository.Delete(utakmica);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
