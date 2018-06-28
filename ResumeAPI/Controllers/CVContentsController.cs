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
    [Route("api/CVContents")]
    public class CVContentsController : Controller
    {
        private readonly DataContext _context;

        public CVContentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CVContents
        [HttpGet("{guid}")]
        public CVContent GetCVContent([FromRoute] string guid)
        {
            return _context.CVContent.Include(x => x.Company)
                                     .Include(x => x.Company.Address)
                                     .SingleOrDefault(x => x.Company.Guid == guid && x.CVType == CVContentType.CoverLetter);
        }


        //// GET: api/CVContents/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCVContent([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var cVContent = await _context.CVContent.SingleOrDefaultAsync(m => m.ID == id);

        //    if (cVContent == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cVContent);
        //}

        //// PUT: api/CVContents/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCVContent([FromRoute] int id, [FromBody] CVContent cVContent)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cVContent.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cVContent).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CVContentExists(id))
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

        //// POST: api/CVContents
        //[HttpPost]
        //public async Task<IActionResult> PostCVContent([FromBody] CVContent cVContent)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.CVContent.Add(cVContent);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCVContent", new { id = cVContent.ID }, cVContent);
        //}

        //// DELETE: api/CVContents/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCVContent([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var cVContent = await _context.CVContent.SingleOrDefaultAsync(m => m.ID == id);
        //    if (cVContent == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CVContent.Remove(cVContent);
        //    await _context.SaveChangesAsync();

        //    return Ok(cVContent);
        //}

        private bool CVContentExists(int id)
        {
            return _context.CVContent.Any(e => e.ID == id);
        }
    }
}