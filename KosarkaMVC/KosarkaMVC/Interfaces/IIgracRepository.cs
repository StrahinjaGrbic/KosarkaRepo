﻿using KosarkaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosarkaMVC.Interfaces
{
    public interface IIgracRepository
    {
        IEnumerable<Igrac> GetAll();
        Igrac GetById(int? id);
        void Create(Igrac igrac);
        void Update(Igrac igrac);
        void Delete(Igrac igrac);
    }
}