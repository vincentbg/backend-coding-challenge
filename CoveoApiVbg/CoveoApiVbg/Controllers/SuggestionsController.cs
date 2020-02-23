using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoveoApiVbg.Data;
using CoveoApiVbg.Interfaces;
using CoveoApiVbg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoveoApiVbg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private ISugggestionLogic suggestionLogic;
        private VilleSuggereeDto villeSuggereeDto;

        public SuggestionsController(ISugggestionLogic suggestionLogic)
        {
            this.suggestionLogic = suggestionLogic;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Suggestion>>> Get(string q, float? latitude, float? longitude)
        { 
         
            IEnumerable<Suggestion> te = await this.suggestionLogic.GetSuggestionsAsync(q, latitude, longitude);

            return Ok(te);

        }

    }
}