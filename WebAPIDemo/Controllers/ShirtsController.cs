using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private List<Shirt> shirtList = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Size = 42, Gender = "Male", Price = 29.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Size = 40, Gender = "Female", Price = 25.99 },
            new Shirt { ShirtId = 3, Brand = "Puma", Color = "Green", Size = 44, Gender = "Male", Price = 32.99 },
            new Shirt { ShirtId = 4, Brand = "Reebok", Color = "Black", Size = 38, Gender = "Female", Price = 27.99 },
            new Shirt { ShirtId = 5, Brand = "Under Armour", Color = "White", Size = 46, Gender = "Male", Price = 34.99 }
        };


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

            var shirt = shirtList.FirstOrDefault(x => x.ShirtId == id);

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
