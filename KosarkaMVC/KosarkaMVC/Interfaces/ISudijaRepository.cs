using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaMVC.Interfaces
{
    public interface ISudijaRepository
    {
        IEnumerable<Sudija> GetAll();
        Sudija GetById(int? id);
        void Create(Sudija sudija);
        void Update(Sudija sudija);
        void Delete(Sudija sudija);
    }
}
