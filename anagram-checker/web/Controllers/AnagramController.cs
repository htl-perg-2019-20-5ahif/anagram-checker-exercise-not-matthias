using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnagramController : ControllerBase
    {
        private readonly ILogger<AnagramController> logger;
        private readonly IAnagramLibrary anagramLibrary;

        public AnagramController(ILogger<AnagramController> logger, IAnagramLibrary anagramLibrary)
        {
            this.logger = logger;
            this.anagramLibrary = anagramLibrary;
        }

        [HttpPost]
        [Route("checkAnagram")]
        public IActionResult CheckAnagram([FromBody] Anagram anagram)
        {
            if (anagram == null || string.IsNullOrEmpty(anagram.W1) || string.IsNullOrEmpty(anagram.W2))
            {
                logger.LogWarning("No anagram found.");
                return BadRequest();
            }

            if (!anagram.IsValid())
            {
                logger.LogWarning("Anagram not valid.");
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route("getKnownAnagrams")]
        public IActionResult CheckAnagram([FromQuery] string name)
        {
            if (name == null || string.IsNullOrEmpty(name))
            {
                logger.LogWarning("No anagram name found.");
                return BadRequest();
            }

            var knownAnagrams = anagramLibrary.GetKnownAnagrams(name).ToList();
            if (knownAnagrams == null || knownAnagrams.Count == 0)
            {
                logger.LogWarning($"\"{name}\" is not in our dictionary.");
                return NotFound();
            }

            return Ok(knownAnagrams);
        }

        [HttpGet]
        [Route("getPermutations")]
        public IActionResult GetPermutations([FromQuery] string name)
        {
            if (name == null || string.IsNullOrEmpty(name))
            {
                logger.LogWarning("No permutation name found.");
                return BadRequest();
            }

            //var permutations = ;
            //if (permutations == null)
            //{
            //    logger.LogWarning("No permutations found.");
            //    return NotFound();
            //}

            return Ok(anagramLibrary.GetPermutations(name));
        }   
    }
}
