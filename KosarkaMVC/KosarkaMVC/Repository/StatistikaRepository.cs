using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KosarkaMVC.Models;

namespace KosarkaMVC.Interfaces
{
    public class StatistikaRepository : IStatistikaRepository, IDisposable
    {
        private KosarkaDBContext db = new KosarkaDBContext();

        public void Create(Statistika statistika)
        {
            db.Statistike.Add(statistika);
            db.SaveChanges();
        }

        public void Delete(Statistika statistika)
        {
            db.Statistike.Remove(statistika);
            db.SaveChanges();
        }

        public IEnumerable<Statistika> GetAll()
        {
            return db.Statistike.Include(s => s.Igrac).Include(s => s.Utakmica).ToList();
        }

        public Statistika GetById(int? id)
        {
            return db.Statistike.Include(s => s.Igrac).Include(s => s.Utakmica).FirstOrDefault(s => s.Id == id);
        }

        public void Update(Statistika statistika)
        {
            db.Entry(statistika).State = EntityState.Modified;
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