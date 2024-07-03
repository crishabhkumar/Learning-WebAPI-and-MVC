using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.DAL;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.Exception_Filter;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        public ShirtsController(ApplicationDBContext db)
        {
            this.dBContext = db;
        }

        //[HttpGet]
        //public string GetShirts()
        //{
        //    return "Reading all the shirts.";
        //}
        [HttpGet]
        public IActionResult GetShirts()
        {
            //return Ok("Reading all the shirts.");
            //return Ok(ShirtRepository.GetShirts());
            return Ok(dBContext.shirts.ToList());
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
        [Shirt_ValidateCreateFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            //return Ok("Creating a shirt.");
            //if (shirt == null)
            //{
            //    return BadRequest();
            //}

            //var shirtTemp = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
            //if (shirtTemp != null)
            //{
            //    return BadRequest();
            //}

            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);
        }


        [HttpGet("{id}")]
        [Shirt_ValidShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            #region Older way befor ActionFilter
            //if(id <= 0)
            //{
            //    return BadRequest();
            //}

            //var shirt = ShirtRepository.GetShirtById(id);

            //if (shirt == null)
            //{
            //    return NotFound();
            //}

            //return Ok(shirt);
            #endregion

            return Ok(ShirtRepository.GetShirtById(id));
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
        [Shirt_ValidShirtIdFilter]
        [Shirt_ValidateUpdateFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult UpdateShirtById(int id, Shirt shirt)
        {
            //if(id != shirt.ShirtId) return BadRequest();  

            //try
            //{
            //    ShirtRepository.UpdateShirt(shirt);
            //}
            //catch (Exception ex)
            //{
            //    if (ShirtRepository.ShirtExists(id))
            //    {
            //        return NotFound();
            //    }
            //    throw;
            //}

            ShirtRepository.UpdateShirt(shirt);

            return NoContent();

            //return Ok($"Updating shirt by ID: {id}");
        }

        [HttpDelete("{id}")]
        [Shirt_ValidShirtIdFilter]
        public IActionResult DeleteShirtById(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);

            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);


            //return Ok($"Deleting shirt by ID: {id}");
        }

    }
}
