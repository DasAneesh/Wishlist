using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYwishlist.Repository;
using MYwishserver;

namespace MYwishserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishesController : ControllerBase
    {
        private readonly DataContext _context;

        public WishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Wishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wish>>> GetWishes()
        {
            return await _context.Wishes.ToListAsync();
        }

        // GET: api/Wishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wish>> GetWish(int id)
        {
            var wish = await _context.Wishes.FindAsync(id);

            if (wish == null)
            {
                return NotFound();
            }

            return wish;
        }

        // PUT: api/Wishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWish(int id, Wish wish)
        {
            if (id != wish.ID)
            {
                return BadRequest();
            }

            _context.Entry(wish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishExists(id))
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

        // POST: api/Wishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wish>> PostWish(Wish wish)
        {
            _context.Wishes.Add(wish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWish", new { id = wish.ID }, wish);
        }

        // DELETE: api/Wishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWish(int id)
        {
            var wish = await _context.Wishes.FindAsync(id);
            if (wish == null)
            {
                return NotFound();
            }

            _context.Wishes.Remove(wish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishExists(int id)
        {
            return _context.Wishes.Any(e => e.ID == id);
        }
    }
}
