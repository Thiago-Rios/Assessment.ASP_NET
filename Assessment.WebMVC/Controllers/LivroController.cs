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
    public class LivroController : Controller
    {
        public ActionResult Index()
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/livros", DataFormat.Json);
            var response = restClient.Get<List<Livro>>(request);

            return View(response.Data);
        }

        public ActionResult Details(int id)
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/livros/" + id, DataFormat.Json);
            var response = restClient.Get<Livro>(request);

            return View(response.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/livros", DataFormat.Json);
            request.AddJsonBody(livro);
            var response = restClient.Post<Livro>(request);

            return Redirect("/livro/index");
        }

        public ActionResult Edit(int id)
        {
            var restClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/livros/" + id, DataFormat.Json);
            var response = restClient.Get<Livro>(request);

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Livro livro)
        {
            try
            {
                var restClient = new RestClient();

                var request = new RestRequest("http://localhost:5000/api/livros/" + id, DataFormat.Json);
                request.AddJsonBody(livro);
                var response = restClient.Put<Livro>(request);

                return Redirect("/livro/index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var novoClient = new RestClient();

            var request = new RestRequest("http://localhost:5000/api/livros/" + id, DataFormat.Json);
            var response = novoClient.Get<Livro>(request);

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest("http://localhost:5000/api/livros/" + id, DataFormat.Json);
                var response = client.Delete<Livro>(request);

                return Redirect("/livro/index");
            }
            catch
            {
                return View();
            }
        }
    }
}