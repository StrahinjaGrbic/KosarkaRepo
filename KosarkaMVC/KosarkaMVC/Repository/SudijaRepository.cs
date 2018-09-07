using KosarkaMVC.Interfaces;
using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Repository
{
    public class SudijaRepository : ISudijaRepository, IDisposable
    {
        private KosarkaDBContext db = new KosarkaDBContext();

        public void Create(Sudija sudija)
        {
            db.Sudije.Add(sudija);
            db.SaveChanges();
        }

        public void Delete(Sudija sudija)
        {
            db.Sudije.Remove(sudija);
            db.SaveChanges();
        }

        public IEnumerable<Sudija> GetAll()
        {
            return db.Sudije.ToList();
        }

        public Sudija GetById(int? id)
        {
            return db.Sudije.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Sudija sudija)
        {
            db.Entry(sudija).State = EntityState.Modified;
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
