using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public class VillesRepository : IRepository
    {
        private IDBcontext context { get; set; }
       
        public VillesRepository(IDBcontext context)
        {
            this.context = context;
            
        }

        public async Task<List<Ville>> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ville>> GetAll()
        {
            return await context.GetAll();
        }
    }
}
