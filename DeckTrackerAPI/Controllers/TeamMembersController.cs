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
    [Route("api/TeamMembers")]
    public class TeamMembersController : Controller
    {
        private readonly DeckTrackerAPIContext _context;

        public TeamMembersController(DeckTrackerAPIContext context)
        {
            _context = context;
        }

        // GET: api/TeamMembers
        [HttpGet]
        public IEnumerable<TeamMember> GetTeamMember()
        {
            return _context.TeamMember;
        }

        // GET: api/TeamMembers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamMember = await _context.TeamMember.SingleOrDefaultAsync(m => m.TeamMemberId == id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return Ok(teamMember);
        }

        // PUT: api/TeamMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember([FromRoute] int id, [FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamMember.TeamMemberId)
            {
                return BadRequest();
            }

            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
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

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<IActionResult> PostTeamMember([FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TeamMember.Add(teamMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMember", new { id = teamMember.TeamMemberId }, teamMember);
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamMember = await _context.TeamMember.SingleOrDefaultAsync(m => m.TeamMemberId == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMember.Remove(teamMember);
            await _context.SaveChangesAsync();

            return Ok(teamMember);
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMember.Any(e => e.TeamMemberId == id);
        }
    }
}