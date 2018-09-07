using KosarkaMVC.Interfaces;
using KosarkaMVC.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Repository
{
    public class UtakmicaRepository : IUtakmicaRepository, IDisposable
    {
        private KosarkaDBContext db = new KosarkaDBContext();

        public void Create(Utakmica utakmica)
        {
            db.Utakmice.Add(utakmica);
            db.SaveChanges();
        }

        public void Delete(Utakmica utakmica)
        {
            db.Utakmice.Remove(utakmica);
            db.SaveChanges();
        }

        public IEnumerable<Utakmica> GetAll()
        {
            return db.Utakmice.Include(u => u.EkipaA).Include(u => u.EkipaB).Include(u => u.Sudija1)
                .Include(u => u.Sudija2).Include(u => u.Sudija3);
        }

        public Utakmica GetById(int? id)
        {
            return db.Utakmice.Include(u => u.EkipaA).Include(u => u.EkipaB).Include(u => u.Sudija1)
                .Include(u => u.Sudija2).Include(u => u.Sudija3).FirstOrDefault(s => s.Id == id);
        }

        public void Update(Utakmica utakmica)
        {
            db.Entry(utakmica).State = EntityState.Modified;
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