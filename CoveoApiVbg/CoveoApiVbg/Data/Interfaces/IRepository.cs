using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public interface IRepository
    {
        Task<List<Suggestion>> GetAll();
        Task<Suggestion> Get(string name);
    }
}
