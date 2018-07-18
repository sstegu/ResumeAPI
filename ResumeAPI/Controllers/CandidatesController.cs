using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeAPI.Models;

namespace ResumeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Candidates")]
    public class CandidatesController : Controller
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        //[HttpGet]
        //public IEnumerable<Candidate> GetCandidate()
        //{
        //    return _context.Candidate.Include(x => x.Address)
        //                                            .Include(x => x.Education)
        //                                            .Include(x => x.WorkHistory).ThenInclude(x => x.Projects);
        //}

        // GET: api/Candidates/5
        [HttpGet("{id}/Resume")]
        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(typeof(Candidate), 200)]
        public async Task<IActionResult> GetCandidate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //FYI..minor pain point-> the .ThenInclude(x=>x.Projects) is not handled by intellisense but compiles fine 
            var candidate = await _context.Candidate.Include(x => x.Address)
                                                    .Include(x => x.Education)
                                                    .Include(x => x.WorkHistory).ThenInclude(x => x.Projects)
                                                    .SingleOrDefaultAsync(m => m.ID == id);

            if (candidate == null)
            {
                return NotFound();
            }
            //order data elements...could have queried each element separately including an order too
            candidate.Education = candidate.Education.OrderByDescending(x => x.Year).ToList<Education>();
            candidate.WorkHistory = candidate.WorkHistory.OrderByDescending(x => x.Start).ToList<WorkHistory>();
            foreach (var workHistory in candidate.WorkHistory)
            {
                workHistory.Projects = workHistory.Projects.OrderBy(x => x.Order).ToList();
            }

            return Ok(candidate);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(typeof(Candidate), 200)]
        public async Task<IActionResult> GetCandidateIndicative([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //FYI..minor pain point-> the .ThenInclude(x=>x.Projects) is not handled by intellisense but compiles fine 
            var candidate = await _context.Candidate.Select(x => new { x.FirstName, x.LastName, x.Phone, x.Email, x.ID })
                                                     .SingleOrDefaultAsync(m => m.ID == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // PUT: api/Candidates/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCandidate([FromRoute] int id, [FromBody] Candidate candidate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != candidate.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(candidate).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CandidateExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Candidates
        //[HttpPost]
        //public async Task<IActionResult> PostCandidate([FromBody] Candidate candidate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Candidate.Add(candidate);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCandidate", new { id = candidate.ID }, candidate);
        //}

        //// DELETE: api/Candidates/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCandidate([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var candidate = await _context.Candidate.SingleOrDefaultAsync(m => m.ID == id);
        //    if (candidate == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Candidate.Remove(candidate);
        //    await _context.SaveChangesAsync();

        //    return Ok(candidate);
        //}

        //private bool CandidateExists(int id)
        //{
        //    return _context.Candidate.Any(e => e.ID == id);
        //}
    }
}