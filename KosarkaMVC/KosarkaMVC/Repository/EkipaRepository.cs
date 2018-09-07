using KosarkaMVC.Helper;
using KosarkaMVC.Interfaces;
using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Repository
{
    public class EkipaRepository : IEkipaRepository, IDisposable
    {
        private KosarkaDBContext db = new KosarkaDBContext();

        public void Create(Ekipa ekipa)
        {
            ekipa.ProcenatUspesnosti = Calculate.Percentage(ekipa.BrojPobeda, ekipa.BrojPoraza);
            ekipa.BrojBodova = Calculate.Points(ekipa.BrojPobeda, ekipa.BrojPoraza);
            ekipa.KosRazlika = Calculate.PointDifference(ekipa.PostignutiPoeni, ekipa.PrimljeniPoeni);
            db.Ekipe.Add(ekipa);
            db.SaveChanges();
        }

        public void Delete(Ekipa ekipa)
        {
            db.Ekipe.Remove(ekipa);
            db.SaveChanges();
        }

        public IEnumerable<Ekipa> GetAll()
        {
            return db.Ekipe.OrderByDescending(e => e.BrojBodova).ToList();
        }

        public Ekipa GetById(int? id)
        {
            return db.Ekipe.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Ekipa ekipa)
        {
            ekipa.ProcenatUspesnosti = Calculate.Percentage(ekipa.BrojPobeda, ekipa.BrojPoraza);
            ekipa.BrojBodova = Calculate.Points(ekipa.BrojPobeda, ekipa.BrojPoraza);
            ekipa.KosRazlika = Calculate.PointDifference(ekipa.PostignutiPoeni, ekipa.PrimljeniPoeni);
            db.Entry(ekipa).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}