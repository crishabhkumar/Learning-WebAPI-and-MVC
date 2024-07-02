using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public string GetShirts()
        {
            return "Reading all the shirts.";
        }

        [HttpPost]
        public string CreateShirt()
        {
            return "Creating a shirt.";
        }

        [HttpGet("{id}")]
        public string GetShirtById(int id)
        {
            return $"Reading shirt by ID: {id}";
        }

        [HttpPut("{id}")]
        public string UpdateShirtById(int id)
        {
            return $"Updating shirt by ID: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirtById(int id)
        {
            return $"Deleting shirt by ID: {id}";
        }

    }
}
