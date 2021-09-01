using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDWithPostgreSQL.DataContext;
using CRUDWithPostgreSQL.Model;

namespace CRUDWithPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;


        //help files
        //https://www.youtube.com/watch?v=Mpl4IWFob4I
        //https://www.npgsql.org/efcore/
        public EmployeeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Empployee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpDTO>>> GetEmpObj()
        {
            return await _context.EmpObj.ToListAsync();
        }

        // GET: api/Empployee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpDTO>> GetEmpDTO(int id)
        {
            var empDTO = await _context.EmpObj.FindAsync(id);

            if (empDTO == null)
            {
                return NotFound();
            }

            return empDTO;
        }

        // PUT: api/Empployee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpDTO(int id, EmpDTO empDTO)
        {
            if (id != empDTO.empid)
            {
                return BadRequest();
            }

            _context.Entry(empDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpDTOExists(id))
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

        // POST: api/Empployee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmpDTO>> PostEmpDTO(EmpDTO empDTO)
        {
            _context.EmpObj.Add(empDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpDTO", new { id = empDTO.empid }, empDTO);
        }

        // DELETE: api/Empployee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpDTO>> DeleteEmpDTO(int id)
        {
            var empDTO = await _context.EmpObj.FindAsync(id);
            if (empDTO == null)
            {
                return NotFound();
            }

            _context.EmpObj.Remove(empDTO);
            await _context.SaveChangesAsync();

            return empDTO;
        }

        private bool EmpDTOExists(int id)
        {
            return _context.EmpObj.Any(e => e.empid == id);
        }
    }
}
