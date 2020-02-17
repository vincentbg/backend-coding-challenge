using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public interface IRepository
    {
        Task<List<Ville>> GetAll();
        Task<List<Ville>> Get(string name);
    }
}
