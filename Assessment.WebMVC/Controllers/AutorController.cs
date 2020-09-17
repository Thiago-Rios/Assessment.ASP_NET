using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Assessment.WebMVC.Controllers
{
    public class AutorController : Controller
    {
        public ActionResult Index()
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/autores", DataFormat.Json);
            var response = restClient.Get<List<Autor>>(request);

            return View(response.Data);
        }

        public ActionResult Details(int id)
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/autores/" + id, DataFormat.Json);
            var response = restClient.Get<Autor>(request);

            return View(response.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/autores", DataFormat.Json);
            request.AddJsonBody(autor);
            var response = restClient.Post<Autor>(request);

            return Redirect("/autor/index");
        }

        public ActionResult Edit(int id)
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/autores/" + id, DataFormat.Json);
            var response = restClient.Get<AutorResponse>(request);

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor autor)
        {
            try
            {
                var restClient = new RestClient();

                var request = new RestRequest("http://localhost:5000/api/autores/" + id, DataFormat.Json);
                request.AddJsonBody(autor);
                var response = restClient.Put<Autor>(request);

                return Redirect("/autor/index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var novoClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/autores/" + id, DataFormat.Json);
            var response = novoClient.Get<Autor>(request);

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest("http://localhost:5000/api/autores/" + id, DataFormat.Json);
                var response = client.Delete<Autor>(request);

                return Redirect("/autor/index");
            }
            catch
            {
                return View();
            }
        }
    }
}