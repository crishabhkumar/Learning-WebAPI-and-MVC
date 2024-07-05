using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly IWebAPIExecuter _executer;
        public ShirtsController(IWebAPIExecuter webAPIExecuter)
        {
            this._executer = webAPIExecuter;

        }
        public async Task<IActionResult> Index()
        {
            //return View(ShirtRepository.GetShirts());
            return View(await _executer.InvokeGet<List<Shirt>>("shirts"));
        }
    }
}
