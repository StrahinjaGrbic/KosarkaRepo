using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaMVC.DAL.SQL.Interfaces
{
    public interface IUtakmicaRepositorySQL
    {
        IEnumerable<Utakmica> GetAll();
        Utakmica GetById(int? id);
        void Create(Utakmica utakmica);
        void Update(Utakmica utakmica);
        void Delete(Utakmica utakmica);
    }
}
