using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeckTrackerAPI.Models;

namespace DeckTrackerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/KeyToVictories")]
    public class KeyToVictoriesController : Controller
    {
        private readonly DeckTrackerAPIContext _context;

        public KeyToVictoriesController(DeckTrackerAPIContext context)
        {
            _context = context;
        }

        // GET: api/KeyToVictories
        [HttpGet]
        public IEnumerable<KeyToVictory> GetKeyToVictory()
        {
            return _context.KeyToVictory;
        }

        // GET: api/KeyToVictories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeyToVictory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var keyToVictory = await _context.KeyToVictory.SingleOrDefaultAsync(m => m.KeyId == id);

            if (keyToVictory == null)
            {
                return NotFound();
            }

            return Ok(keyToVictory);
        }

        // PUT: api/KeyToVictories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyToVictory([FromRoute] int id, [FromBody] KeyToVictory keyToVictory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyToVictory.KeyId)
            {
                return BadRequest();
            }

            _context.Entry(keyToVictory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyToVictoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KeyToVictories
        [HttpPost]
        public async Task<IActionResult> PostKeyToVictory([FromBody] KeyToVictory keyToVictory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.KeyToVictory.Add(keyToVictory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyToVictory", new { id = keyToVictory.KeyId }, keyToVictory);
        }

        // DELETE: api/KeyToVictories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyToVictory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var keyToVictory = await _context.KeyToVictory.SingleOrDefaultAsync(m => m.KeyId == id);
            if (keyToVictory == null)
            {
                return NotFound();
            }

            _context.KeyToVictory.Remove(keyToVictory);
            await _context.SaveChangesAsync();

            return Ok(keyToVictory);
        }

        private bool KeyToVictoryExists(int id)
        {
            return _context.KeyToVictory.Any(e => e.KeyId == id);
        }
    }
}