using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetCoreAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace DotNetCoreAPI.Controllers
{
   
    [Produces("application/json")]
    [Route("api/EmpMasters")]
    public class EmpMastersController : Controller
    {
        private readonly DBFirstContext _context;

        public EmpMastersController(DBFirstContext context)
        {
            _context = context;
        }

        // GET: api/EmpMasters
        [HttpGet]
        [DisableCors]
        public IEnumerable<EmpMaster> GetEmpMaster()
        {
            return _context.EmpMaster;
        }

        // GET: api/EmpMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpMaster([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empMaster = await _context.EmpMaster.SingleOrDefaultAsync(m => m.RowId == id);

            if (empMaster == null)
            {
                return NotFound();
            }

            return Ok(empMaster);
        }

        // PUT: api/EmpMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpMaster([FromRoute] decimal id, [FromBody] EmpMaster empMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empMaster.RowId)
            {
                return BadRequest();
            }

            _context.Entry(empMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpMasterExists(id))
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

        // POST: api/EmpMasters
        [HttpPost]
        public async Task<IActionResult> PostEmpMaster([FromBody] EmpMaster empMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmpMaster.Add(empMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpMaster", new { id = empMaster.RowId }, empMaster);
        }

        // DELETE: api/EmpMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpMaster([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empMaster = await _context.EmpMaster.SingleOrDefaultAsync(m => m.RowId == id);
            if (empMaster == null)
            {
                return NotFound();
            }

            _context.EmpMaster.Remove(empMaster);
            await _context.SaveChangesAsync();

            return Ok(empMaster);
        }

        private bool EmpMasterExists(decimal id)
        {
            return _context.EmpMaster.Any(e => e.RowId == id);
        }
    }
}