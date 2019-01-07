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
    public class OrdersController : ControllerBase
    {
        private readonly AppContext _context;

        public OrdersController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders
                .Include(e => e.FoodWithOrders)
                .ThenInclude(e => e.Food)
                .Include(e => e.FoodWithOrders)
                .ThenInclude(e => e.Order)
                .Include(e => e.TableWithOrders).ToList();

            var jObject = Utils.getJObjectResponseFromArray(true, orders);
            return Ok(jObject);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var jObject = Utils.getJObjectResponseFromObject(true, order);
            return Ok(jObject);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] long id, [FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // PUT: api/Orders/5
        [HttpPut("updatefood/{id}")]
        public async Task<IActionResult> UpdateFood([FromRoute] long id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                var _order = await _context.Orders.FindAsync(id);
                var newList = new List<FoodWithOrder>();
                foreach (FoodWithOrder fwo in order.FoodWithOrders)
                {
                    var found = await _context.FoodWithOrders.SingleOrDefaultAsync(c => c.OrderId == fwo.OrderId && c.FoodId == fwo.FoodId);
                    //foreach (FoodWithOrder f in _order.FoodWithOrders)
                    //{
                    //    if (f.OrderId != fwo.OrderId && f.FoodId != fwo.FoodId)
                    //    {
                    //        newList.Add(fwo);
                    //    }
                    //}
                    //if (!found) _order.FoodWithOrders.Add(fwo);
                    if (found == null)
                    {
                        newList.Add(fwo);
                    }
                    else
                    {
                        if(fwo.Quantities > 0)
                        {
                            found.Quantities = fwo.Quantities;
                            newList.Add(found);
                        }
                        else
                        {
                            _order.FoodWithOrders.Remove(found);
                        }
                    }
                }

                _order.FoodWithOrders = newList;
                await _context.SaveChangesAsync();
                var returnObj = await _context.Orders.Include(e => e.FoodWithOrders)
                    .ThenInclude(e => e.Food)
                    .Include(e => e.FoodWithOrders)
                    .ThenInclude(e => e.Order)
                    .Include(e => e.TableWithOrders)
                    .SingleOrDefaultAsync(e => e.Id == id);
                var jObject = Utils.getJObjectResponseFromObject(true, _order);
                return Ok(jObject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            var jObject = Utils.getJObjectResponseFromObject(true, order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, jObject);
        }

        // POST: api/Orders
        [HttpPost("new")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            string error = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //foreach (TableWithOrder tb in order.TableWithOrders)
                //{
                //    var index = _context.Tables.SingleOrDefault(e => e.TableId == tb.TableId).Id;
                //    tb.Id = index;
                //}

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }

            var jObject = Utils.getJObjectResponseFromObject(true, order, error);

            return CreatedAtAction("GetOrder", new { id = order.Id }, jObject);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(Utils.getJObjectResponseFromObject(true, order));
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}