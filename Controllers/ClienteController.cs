using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteAPI.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Cliente/");
                response.EnsureSuccessStatusCode();
                //List<Models.CategoryViewModel> categories = new List<Models.CategoryViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.ClienteViewModel> clientes = JsonConvert.DeserializeObject<List<Models.ClienteViewModel>>(content);

                ViewBag.Title = "All Clientes";
                return View(clientes);
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


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel clientesViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(clientesViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ClienteViewModel clientes, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Cliente", clientes);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/Cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel categoryViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(categoryViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.ClienteViewModel clientes, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Cliente", clientes);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel clientesViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(clientesViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.ClienteViewModel clientes)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Cliente/" + clientes.IdCliente.ToString());
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
