using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        readonly private IBLRepo _bl;

        public CartsController(IBLRepo bl)
        {
            _bl = bl;
        }

        // GET: api/<CartsController>/getcarts/peter/7811112222
        [HttpGet("getsales/{buyerName}/{phoneNumber}")]
        public async Task<IActionResult> GetCarts(string buyerName, long phoneNumber)
        {
            List<Cart> carts = await _bl.GetCartsAsync(buyerName, phoneNumber);
            if (carts.Count != 0)
            {
                return Ok(carts);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<CartsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cart newCart)
        {
            Cart cart = await _bl.AddToCartAsync(newCart);
            return Created("api/[controller]", cart);
        }

        // PUT api/<CartsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Cart updatedCart)
        {
            Cart cart = await _bl.UpdateCartAsync(updatedCart);
            return Ok(cart);
        }

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteCartAsync(id);
        }
    }
}
