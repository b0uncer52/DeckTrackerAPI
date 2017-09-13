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
    [Route("api/RecordKeys")]
    public class RecordKeysController : Controller
    {
        private readonly DeckTrackerAPIContext _context;

        public RecordKeysController(DeckTrackerAPIContext context)
        {
            _context = context;
        }

        // GET: api/RecordKeys
        [HttpGet]
        public IEnumerable<RecordKey> GetRecordKey()
        {
            return _context.RecordKey;
        }

        // GET: api/RecordKeys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordKey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordKey = await _context.RecordKey.SingleOrDefaultAsync(m => m.RecordKeyId == id);

            if (recordKey == null)
            {
                return NotFound();
            }

            return Ok(recordKey);
        }

        // PUT: api/RecordKeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordKey([FromRoute] int id, [FromBody] RecordKey recordKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordKey.RecordKeyId)
            {
                return BadRequest();
            }

            _context.Entry(recordKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordKeyExists(id))
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

        // POST: api/RecordKeys
        [HttpPost]
        public async Task<IActionResult> PostRecordKey([FromBody] RecordKey recordKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RecordKey.Add(recordKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecordKey", new { id = recordKey.RecordKeyId }, recordKey);
        }

        // DELETE: api/RecordKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordKey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordKey = await _context.RecordKey.SingleOrDefaultAsync(m => m.RecordKeyId == id);
            if (recordKey == null)
            {
                return NotFound();
            }

            _context.RecordKey.Remove(recordKey);
            await _context.SaveChangesAsync();

            return Ok(recordKey);
        }

        private bool RecordKeyExists(int id)
        {
            return _context.RecordKey.Any(e => e.RecordKeyId == id);
        }
    }
}