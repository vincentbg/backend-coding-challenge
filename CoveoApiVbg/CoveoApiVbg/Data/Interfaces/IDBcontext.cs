using CoveoApiVbg.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public interface IDBcontext
    {
        Task<List<Suggestion>> GetAll();
        Task<Suggestion> Get(string name);
    }
}