using ClienteAPI.Helpers;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {


                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Authenticate/login", model);
                response.EnsureSuccessStatusCode();
                TokenModel tokenModel = response.Content.ReadAsAsync<TokenModel>().Result;

                var token = tokenModel.Token;

                HttpContext.Session.SetString("JWTToken", token);

                return RedirectToAction("index", "home");

            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(model);
        

    }


}
}
