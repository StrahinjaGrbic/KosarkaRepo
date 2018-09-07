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

namespace KosarkaMVC.Controllers
{
    public class SudijeController : Controller
    {
        private ISudijaRepository _sudijaRepository;

        public SudijeController(ISudijaRepository sudijaRepository)
        {
            _sudijaRepository = sudijaRepository;
        }

        // GET: Sudije
        public ActionResult Index()
        {
            return View(_sudijaRepository.GetAll());
        }

        // GET: Sudije/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudija sudija = _sudijaRepository.GetById(id);
            if (sudija == null)
            {
                return HttpNotFound();
            }
            return View(sudija);
        }

        // GET: Sudije/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sudije/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Prezime")] Sudija sudija)
        {
            if (ModelState.IsValid)
            {
                _sudijaRepository.Create(sudija);
                return RedirectToAction("Index");
            }

            return View(sudija);
        }

        // GET: Sudije/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudija sudija = _sudijaRepository.GetById(id);
            if (sudija == null)
            {
                return HttpNotFound();
            }
            return View(sudija);
        }

        // POST: Sudije/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Prezime")] Sudija sudija)
        {
            if (ModelState.IsValid)
            {
                _sudijaRepository.Update(sudija);
                return RedirectToAction("Index");
            }
            return View(sudija);
        }

        // GET: Sudije/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sudija sudija = _sudijaRepository.GetById(id);
            if (sudija == null)
            {
                return HttpNotFound();
            }
            return View(sudija);
        }

        // POST: Sudije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sudija sudija = _sudijaRepository.GetById(id);
            _sudijaRepository.Delete(sudija);
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
