using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteAPI.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Proveedores/");
                response.EnsureSuccessStatusCode();
                //List<Models.CategoryViewModel> categories = new List<Models.CategoryViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.ProveedoresViewModel> proveedores = JsonConvert.DeserializeObject<List<Models.ProveedoresViewModel>>(content);

                ViewBag.Title = "All Proveedores";
                return View(proveedores);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: CategoryController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            string accessToken = HttpContext.Session.GetString("JWTToken");

            ServiceRepository serviceObj = new ServiceRepository(accessToken);
            HttpResponseMessage response = serviceObj.GetResponse("api/Proveedores/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ProveedoresViewModel proveedoresViewModel = response.Content.ReadAsAsync<Models.ProveedoresViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(proveedoresViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ProveedoresViewModel proveedores, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Proveedores", proveedores);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Proveedores/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ProveedoresViewModel categoryViewModel = response.Content.ReadAsAsync<Models.ProveedoresViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(categoryViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.ProveedoresViewModel proveedores, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Proveedores", proveedores);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Proveedores/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ProveedoresViewModel proveedoresViewModel = response.Content.ReadAsAsync<Models.ProveedoresViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(proveedoresViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.ProveedoresViewModel proveedores)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Proveedores/" + proveedores.IdProveedor.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

            if (!Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
