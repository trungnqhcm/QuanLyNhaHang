using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangServer;
using QuanLyNhaHangServer.Helpers;
using QuanLyNhaHangServer.Models;

namespace QuanLyNhaHangServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly AppContext _context;

        public FoodsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Foods
        [HttpGet]
        public IActionResult GetFoods()
        {
            var jObject = Utils.getJObjectResponseFromArray(true, _context.Foods.ToList());
            return Ok(jObject);
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var food = await _context.Foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }
            var jObject = Utils.getJObjectResponseFromObject(true, food);
            return Ok(jObject);
        }

        // PUT: api/Foods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood([FromRoute] long id, [FromForm] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _food = _context.Foods.SingleOrDefault(f => f.name == food.name);

            try
            {
                if (_food != null)
                {
                  
                    _food.FoodCategory = food.FoodCategory;
                    _food.ImageId = food.ImageId;
                    food.Ingredients = food.Ingredients;
                    food.Price = food.Price;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(food.name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Utils.getJObjectResponseFromObject(true, _food));
        }

        // POST: api/Foods
        [HttpPost]
        public async Task<IActionResult> PostFood([FromForm] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            var jObject = Utils.getJObjectResponseFromObject(true, food);
            return CreatedAtAction("GetFood", new { id = food.Id }, jObject);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return Ok(Utils.getJObjectResponseFromObject(true, food));
        }

        private bool FoodExists(string name)
        {
            return _context.Foods.Any(e => e.name == name);
        }
    }
}