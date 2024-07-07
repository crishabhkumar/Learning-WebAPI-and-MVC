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

        public IActionResult CreateShirt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShirt(Shirt shirt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _executer.InvokePost<Shirt>("shirts", shirt);
                    if (response != null)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (WebAPIException ex)
                {
                    if(ex.ErrorResponse != null
                        && ex.ErrorResponse.Errors != null
                        && ex.ErrorResponse.Errors.Count > 0)
                    {
                        foreach (var erro in ex.ErrorResponse.Errors)
                        {
                            ModelState.AddModelError(erro.Key, string.Join("; ", erro.Value));
                        }
                    }
                }
            }
            return View(shirt);
        }

        public async Task<IActionResult> UpdateShirt(int shirtID)
        {
            var shirt = await _executer.InvokeGet<Shirt>($"shirts/{shirtID}");
            if (shirt != null)
            {
                return View(shirt);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShirt(Shirt shirt)
        {
            if (ModelState.IsValid)
            {
                await _executer.InvokePut($"shirts/{shirt.ShirtId}", shirt);
                return RedirectToAction("Index");
            }

            return View(shirt);
        }
        public async Task<IActionResult> DeleteShirt(int shirtID)
        {
            var shirt = await _executer.InvokeGet<Shirt>($"shirts/{shirtID}");
            if (shirt != null)
            {
                await _executer.InvokeDelete($"shirts/{shirtID}");
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
