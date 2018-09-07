using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaMVC.Interfaces
{
    public interface IEkipaRepository
    {
        IEnumerable<Ekipa> GetAll();
        Ekipa GetById(int? id);
        void Create(Ekipa ekipa);
        void Update(Ekipa ekipa);
        void Delete(Ekipa ekipa);
    }
}
