using CoveoApiVbg.Data;
using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Interfaces
{
    public interface ISuggestionFactory
    {
        public Suggestion Create(int id, string name, string tz, string country, float score, float latitude, float longitude);
    }

}
