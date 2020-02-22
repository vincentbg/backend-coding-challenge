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
           
           
            return Ok(suggestions);

        }
    }
}