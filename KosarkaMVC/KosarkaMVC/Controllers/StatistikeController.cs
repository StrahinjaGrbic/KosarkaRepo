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
    public class StatistikeController : Controller
    {
        private IStatistikaRepository _statistikaRepository;
        private IIgracRepository _igracRepository;
        private IUtakmicaRepository _utakmicaRepository;

        public StatistikeController(IStatistikaRepository statistikaRepository, IIgracRepository igracRepository,
            IUtakmicaRepository utakmicaRepository)
        {
            _statistikaRepository = statistikaRepository;
            _igracRepository = igracRepository;
            _utakmicaRepository = utakmicaRepository;
        }

        // GET: Statistike
        public ActionResult Index()
        {
            return View(_statistikaRepository.GetAll());
        }

        // GET: Statistike/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistika statistika = _statistikaRepository.GetById(id);
            if (statistika == null)
            {
                return HttpNotFound();
            }
            return View(statistika);
        }

        // GET: Statistike/Create
        public ActionResult Create()
        {
            ViewBag.IgracId = new SelectList(_igracRepository.GetAll(), "Id", "Ime");
            ViewBag.UtakmicaId = new SelectList(_utakmicaRepository.GetAll(), "Id", "Sezona");
            return View();
        }

        // POST: Statistike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UtakmicaId,IgracId,BrojDresa,Minutaza,TwoptA,TwoptM,ThreeptA,ThreeptM,FtA,FtM,OReb,DReb,Reb,Ast,To,Stl,Blk,Pts,Fd,Fc,Pir")] Statistika statistika)
        {
            if (ModelState.IsValid)
            {
                _statistikaRepository.Create(statistika);
                return RedirectToAction("Index");
            }

            ViewBag.IgracId = new SelectList(_igracRepository.GetAll(), "Id", "Ime", statistika.IgracId);
            ViewBag.UtakmicaId = new SelectList(_utakmicaRepository.GetAll(), "Id", "Sezona", statistika.UtakmicaId);
            return View(statistika);
        }

        // GET: Statistike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistika statistika = _statistikaRepository.GetById(id);
            if (statistika == null)
            {
                return HttpNotFound();
            }
            ViewBag.IgracId = new SelectList(_igracRepository.GetAll(), "Id", "Ime", statistika.IgracId);
            ViewBag.UtakmicaId = new SelectList(_utakmicaRepository.GetAll(), "Id", "Sezona", statistika.UtakmicaId);
            return View(statistika);
        }

        // POST: Statistike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UtakmicaId,IgracId,BrojDresa,Minutaza,TwoptA,TwoptM,ThreeptA,ThreeptM,FtA,FtM,OReb,DReb,Reb,Ast,To,Stl,Blk,Pts,Fd,Fc,Pir")] Statistika statistika)
        {
            if (ModelState.IsValid)
            {
                _statistikaRepository.Update(statistika);
                return RedirectToAction("Index");
            }
            ViewBag.IgracId = new SelectList(_igracRepository.GetAll(), "Id", "Ime", statistika.IgracId);
            ViewBag.UtakmicaId = new SelectList(_utakmicaRepository.GetAll(), "Id", "Sezona", statistika.UtakmicaId);
            return View(statistika);
        }

        // GET: Statistike/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistika statistika = _statistikaRepository.GetById(id);
            if (statistika == null)
            {
                return HttpNotFound();
            }
            return View(statistika);
        }

        // POST: Statistike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statistika statistika = _statistikaRepository.GetById(id);
            _statistikaRepository.Delete(statistika);
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
