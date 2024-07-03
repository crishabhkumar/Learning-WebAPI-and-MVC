using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        //[HttpGet]
        //public string GetShirts()
        //{
        //    return "Reading all the shirts.";
        //}
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts.");
        }

        //[HttpPost]
        //public string CreateShirt([FromForm]Shirt shirt)
        //{
        //    return "Creating a shirt.";
        //}

        //FromBody Example
        //[HttpPost]
        //public string CreateShirt([FromBody] Shirt shirt)
        //{
        //    return "Creating a shirt.";
        //}

        [HttpPost]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok("Creating a shirt.");
        }


        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var shirt = ShirtRepository.GetShirtById(id);

            if (shirt == null)
            {
                return NotFound();
            }

            return Ok(shirt);
        }

        //[HttpGet("{id}")]
        //public string GetShirtById(int id)
        //{
        //    return $"Reading shirt by ID: {id}";
        //}

        #region FromRoute,FromQuery,FromHeader Examples
        ////FromRoute
        //[HttpGet("{id}/{color}")]
        //public string GetShirtById(int id,[FromRoute]string color)
        //{
        //    return $"Reading shirt by ID: {id}, Color : {color}";
        //}

        //FromQuery
        //[HttpGet("{id}")]
        //public string GetShirtById(int id, [FromQuery] string Color)
        //{
        //    return $"Reading shirt by ID: {id}, Color:{Color}";
        //}

        //FromHeader
        //[HttpGet("{id}")]
        //public string GetShirtById(int id, [FromHeader(Name = "Color")]string Color)
        //{
        //    return $"Reading shirt by ID: {id}, Color:{Color}";
        //}
        #endregion

        //[HttpPut("{id}")]
        //public string UpdateShirtById(int id)
        //{
        //    return $"Updating shirt by ID: {id}";
        //}

        //[HttpDelete("{id}")]
        //public string DeleteShirtById(int id)
        //{
        //    return $"Deleting shirt by ID: {id}";
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateShirtById(int id)
        {
            return Ok($"Updating shirt by ID: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirtById(int id)
        {
            return Ok($"Deleting shirt by ID: {id}");
        }

    }
}
