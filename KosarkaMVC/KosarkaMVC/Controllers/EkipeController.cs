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
    public class EkipeController : Controller
    {
        private IEkipaRepository _ekipaRepository = new EkipaRepository();

        //public EkipeController()
        //{

        //}

        //public EkipeController(IEkipaRepository ekipaRepository)
        //{
        //    _ekipaRepository = ekipaRepository;
        //}

        // GET: Ekipe
        public ActionResult Index()
        {
            return View(_ekipaRepository.GetAll());
        }

        // GET: Ekipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = _ekipaRepository.GetById(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            return View(ekipa);
        }

        // GET: Ekipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ekipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Sezona,Trener,BrojBodova,BrojPobeda,BrojPoraza,ProcenatUspesnosti,PostignutiPoeni,PrimljeniPoeni,KosRazlika")] Ekipa ekipa)
        {
            if (ModelState.IsValid)
            {
                _ekipaRepository.Create(ekipa);
                return RedirectToAction("Index");
            }

            return View(ekipa);
        }

        // GET: Ekipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = _ekipaRepository.GetById(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            return View(ekipa);
        }

        // POST: Ekipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Sezona,Trener,BrojBodova,BrojPobeda,BrojPoraza,ProcenatUspesnosti,PostignutiPoeni,PrimljeniPoeni,KosRazlika")] Ekipa ekipa)
        {
            if (ModelState.IsValid)
            {
                _ekipaRepository.Update(ekipa);
                return RedirectToAction("Index");
            }
            return View(ekipa);
        }

        // GET: Ekipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = _ekipaRepository.GetById(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            return View(ekipa);
        }

        // POST: Ekipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ekipa ekipa = _ekipaRepository.GetById(id);
            _ekipaRepository.Delete(ekipa);
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
