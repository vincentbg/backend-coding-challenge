using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoveoApiVbg.Data;
using CoveoApiVbg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoveoApiVbg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private IRepository suggestionsRepo;

        public SuggestionsController(IRepository suggestionsRepo)
        {
            this.suggestionsRepo = suggestionsRepo;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Suggestion>>> Get(string q, float? latitude, float? longitude)
        {
            var rng = q;

            if (latitude.HasValue && longitude.HasValue)
            {
                rng += latitude.ToString();
            }
             List<Ville> suggestions = await suggestionsRepo.GetAll();
            //suggestions.Add(new Suggestion { Id = 1, Latitude = 0, Longitude = 0, Name = "London", Score = 1 });
            //suggestions.Add(new Suggestion { Id = 2, Latitude = 0, Longitude = 0, Name = "Quebec", Score = 0 });
            suggestions.Add(new Ville { Id = suggestions.Count });
            return Ok(suggestions);

        }
    }
}