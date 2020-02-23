using CoveoApiVbg.Data;
using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Interfaces
{
    public interface ISugggestionLogic
    {
        public Task WriteMessage(string msg);

        public Task<IEnumerable<Suggestion>> GetSuggestionsAsync(string q, float? latitude, float ? longitude);



    }
}
