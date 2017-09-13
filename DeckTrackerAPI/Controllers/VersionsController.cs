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
    [Route("api/Versions")]
    public class VersionsController : Controller
    {
        private readonly DeckTrackerAPIContext _context;

        public VersionsController(DeckTrackerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Versions
        [HttpGet]
        public IEnumerable<Models.Version> GetVersion()
        {
            return _context.Version;
        }

        // GET: api/Versions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVersion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var version = await _context.Version.SingleOrDefaultAsync(m => m.VersionId == id);

            if (version == null)
            {
                return NotFound();
            }

            return Ok(version);
        }

        // PUT: api/Versions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVersion([FromRoute] int id, [FromBody] Models.Version version)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != version.VersionId)
            {
                return BadRequest();
            }

            _context.Entry(version).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionExists(id))
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

        // POST: api/Versions
        [HttpPost]
        public async Task<IActionResult> PostVersion([FromBody] Models.Version version)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Version.Add(version);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVersion", new { id = version.VersionId }, version);
        }

        // DELETE: api/Versions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVersion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var version = await _context.Version.SingleOrDefaultAsync(m => m.VersionId == id);
            if (version == null)
            {
                return NotFound();
            }

            _context.Version.Remove(version);
            await _context.SaveChangesAsync();

            return Ok(version);
        }

        private bool VersionExists(int id)
        {
            return _context.Version.Any(e => e.VersionId == id);
        }
    }
}