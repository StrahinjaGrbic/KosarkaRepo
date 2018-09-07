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
            return db.Ekipe.ToList();
        }

        public Ekipa GetById(int? id)
        {
            return db.Ekipe.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Ekipa ekipa)
        {
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