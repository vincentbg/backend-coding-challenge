using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public class SuggestionsRepository : IRepository
    {
        private IDBcontext context { get; set; }
       
        public SuggestionsRepository(IDBcontext context)
        {
            this.context = context;
            
        }

        public async Task<Suggestion> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Suggestion>> GetAll()
        {
            return await context.GetAll();
        }
    }
}
