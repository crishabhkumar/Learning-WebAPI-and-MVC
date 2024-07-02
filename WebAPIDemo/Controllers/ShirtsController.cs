using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShirtsController : ControllerBase
    {   
        [HttpGet]
        [Route("/shirts")]
        public string GetShirts()
        {
            return "Reading all the shirts.";
        }

        [HttpPost]
        [Route("/shirts")]
        public string CreateShirt()
        {
            return "Creating a shirt.";
        }

        [HttpGet]
        [Route("/shirts/{id}")]
        public string GetShirtById(int id)
        {
            return $"Reading shirt by ID: {id}";
        }

        [HttpPut]
        [Route("/shirts/{id}")]
        public string UpdateShirtById(int id)
        {
            return $"Updating shirt by ID: {id}";
        }

        [HttpDelete]
        [Route("/shirts/{id}")]
        public string DeleteShirtById(int id)
        {
            return $"Deleting shirt by ID: {id}";
        }

    }
}
