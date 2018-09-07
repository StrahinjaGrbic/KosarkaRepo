using KosarkaMVC.Interfaces;
using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Repository
{
    public class IgracRepository : IIgracRepository, IDisposable
    {
        private KosarkaDBContext db = new KosarkaDBContext();

        public void Create(Igrac igrac)
        {
            db.Igraci.Add(igrac);
            db.SaveChanges();
        }

        public void Delete(Igrac igrac)
        {
            db.Igraci.Remove(igrac);
            db.SaveChanges();
        }

        public IEnumerable<Igrac> GetAll()
        {
            return db.Igraci.Include(e => e.Ekipa).ToList();
        }

        public Igrac GetById(int? id)
        {
            return db.Igraci.Include(e => e.Ekipa).FirstOrDefault(i => i.Id == id);
        }

        public void Update(Igrac igrac)
        {
            db.Entry(igrac).State = EntityState.Modified;
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