using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        HttpClient _httpClient;
        public ProductAdminController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAllProducts()
        {
            var categorieiUrl = "https://localhost:7149/api/Categorie/GetAllCategory";
            var httpClientcategoriei = new HttpClient();
            var reponsecategoriei = await httpClientcategoriei.GetAsync(categorieiUrl);
            string apiDatacategoriei = await reponsecategoriei.Content.ReadAsStringAsync();
            var listCategorie = JsonConvert.DeserializeObject<List<Categories>>(apiDatacategoriei);
            ViewBag.Categorie = listCategorie;

            var ChefUrl = "https://localhost:7149/api/Chef/GetAllChef";
            var httpClientChef = new HttpClient();
            var reponseChef = await httpClientChef.GetAsync(ChefUrl);
            string apiDataChef = await reponseChef.Content.ReadAsStringAsync();
            var listChef = JsonConvert.DeserializeObject<List<Chef>>(apiDataChef);
            ViewBag.Chef = listChef;

            var ProducerUrl = "https://localhost:7149/api/producer/GetProducers";
            var httpClientProducer = new HttpClient();
            var reponseProducer = await httpClientProducer.GetAsync(ProducerUrl);
            string apiDataProducer = await reponseProducer.Content.ReadAsStringAsync();
            var listProducer = JsonConvert.DeserializeObject<List<Producer>>(apiDataProducer);
            ViewBag.Producer = listProducer;


            string apiUrl = $"https://localhost:7149/api/Products/GetAllProducts";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Products>>(apiData);
            return View(products);
        }
        public async Task<IActionResult> CreateProducts()
        {
            var categorieiUrl = "https://localhost:7149/api/Categorie/GetAllCategory";
            var httpClientcategoriei = new HttpClient();
            var reponsecategoriei = await httpClientcategoriei.GetAsync(categorieiUrl);
            string apiDatacategoriei = await reponsecategoriei.Content.ReadAsStringAsync();
            var listCategorie = JsonConvert.DeserializeObject<List<Categories>>(apiDatacategoriei);
            ViewBag.Categorie = listCategorie;

            var ChefUrl = "https://localhost:7149/api/Chef/GetAllChef";
            var httpClientChef = new HttpClient();
            var reponseChef = await httpClientChef.GetAsync(ChefUrl);
            string apiDataChef = await reponseChef.Content.ReadAsStringAsync();
            var listChef = JsonConvert.DeserializeObject<List<Chef>>(apiDataChef);
            ViewBag.Chef = listChef;

            var ProducerUrl = "https://localhost:7149/api/producer/GetProducers";
            var httpClientProducer = new HttpClient();
            var reponseProducer = await httpClientProducer.GetAsync(ProducerUrl);
            string apiDataProducer = await reponseProducer.Content.ReadAsStringAsync();
            var listProducer = JsonConvert.DeserializeObject<List<Producer>>(apiDataProducer);
            ViewBag.Producer = listProducer;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProducts(Products p, IFormFile imageFile)
        {
            string apiURL = $"https://localhost:7149/api/Products/PostProducts";
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                p.Desciption = imageFile.FileName;
            }
            var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllProducts");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ProductsDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Products/GetProductsById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Products>(apiData);
            return View(products);
        }
        public async Task<IActionResult> EditProducts(Guid id)
        {
            var categorieiUrl = "https://localhost:7149/api/Categorie/GetAllCategory";
            var httpClientcategoriei = new HttpClient();
            var reponsecategoriei = await httpClientcategoriei.GetAsync(categorieiUrl);
            string apiDatacategoriei = await reponsecategoriei.Content.ReadAsStringAsync();
            var listCategorie = JsonConvert.DeserializeObject<List<Categories>>(apiDatacategoriei);
            ViewBag.Categorie = listCategorie;

            var ChefUrl = "https://localhost:7149/api/Chef/GetAllChef";
            var httpClientChef = new HttpClient();
            var reponseChef = await httpClientChef.GetAsync(ChefUrl);
            string apiDataChef = await reponseChef.Content.ReadAsStringAsync();
            var listChef = JsonConvert.DeserializeObject<List<Chef>>(apiDataChef);
            ViewBag.Chef = listChef;

            var ProducerUrl = "https://localhost:7149/api/producer/GetProducers";
            var httpClientProducer = new HttpClient();
            var reponseProducer = await httpClientProducer.GetAsync(ProducerUrl);
            string apiDataProducer = await reponseProducer.Content.ReadAsStringAsync();
            var listProducer = JsonConvert.DeserializeObject<List<Producer>>(apiDataProducer);
            ViewBag.Producer = listProducer;


            string apiURL = $"https://localhost:7149/api/Products/GetProductsById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Products>(apiData);
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> EditProducts(Guid id, Products p, IFormFile imageFile)
        {
            string apiURL = $"https://localhost:7149/api/Products/UpdateProducts/{id}";

            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                p.Desciption = imageFile.FileName;
            }
            /* string apiURL = $"https://localhost:7149/api/Products/UpdateProducts/{id}?Name={p.ProductName}" +
                 $"?quantity={p.Quantity}?EntryPrice={p.EntryPrice}?EntryPrice={p.EntryPrice}?DateOfManufacture={p.DateOfManufacture}" +
                 $"?Expired={p.Expired}?EntryPrice={p.EntryPrice}?ImPortDate={p.ImPortDate}?Price={p.Price}" +
                 $"?Status={p.Status}?Desciption={p.Desciption}";*/
            var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllProducts");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProducts(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Products/DeleteProducts/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllProducts");
            }
            return BadRequest();
        }
    }
}
