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
        //[Shirt_ValidateCreateFilter]
        [TypeFilter(typeof(Shirt_ValidateCreateFilterAttribute))]
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

            //ShirtRepository.AddShirt(shirt);
            dBContext.Add(shirt);
            dBContext.SaveChanges();

            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);
        }


        [HttpGet("{id}")]
        //[Shirt_ValidShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidShirtIdFilterAttribute))]
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

            //return Ok(ShirtRepository.GetShirtById(id));
            return Ok(HttpContext.Items["shirt"]);
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
        //[Shirt_ValidShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionFilterAttribute))]
        //[Shirt_HandleUpdateExceptionFilter]
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

            //ShirtRepository.UpdateShirt(shirt);

            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;

            dBContext.SaveChanges();

            return NoContent();

            //return Ok($"Updating shirt by ID: {id}");
        }

        [HttpDelete("{id}")]
        //[Shirt_ValidShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidShirtIdFilterAttribute))]
        public IActionResult DeleteShirtById(int id)
        {
            //var shirt = ShirtRepository.GetShirtById(id);

            //ShirtRepository.DeleteShirt(id);

            var shirt = HttpContext.Items["shirt"] as Shirt;

            dBContext.shirts.Remove(shirt);
            dBContext.SaveChanges();

            return Ok(shirt);


            //return Ok($"Deleting shirt by ID: {id}");
        }

    }
}
