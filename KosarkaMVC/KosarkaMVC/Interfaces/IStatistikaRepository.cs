using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaMVC.Interfaces
{
    public interface IStatistikaRepository
    {
        IEnumerable<Statistika> GetAll();
        Statistika GetById(int? id);
        void Create(Statistika statistika);
        void Update(Statistika statistika);
        void Delete(Statistika statistika);
    }
}
