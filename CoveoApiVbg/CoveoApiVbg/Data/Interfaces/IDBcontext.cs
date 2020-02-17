using CoveoApiVbg.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public interface IDBcontext
    {
        Task<List<Ville>> GetAll();
        Task<List<Ville>> Get(string name);
    }
}