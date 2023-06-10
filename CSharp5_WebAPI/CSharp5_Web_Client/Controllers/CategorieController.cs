using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class CategorieController : Controller
    {
        private HttpClient _httpClient;
        public CategorieController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllCategorie()
        {
            string apiUrl = "https://localhost:7149/api/Categorie/GetAllCategory";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var categorie = JsonConvert.DeserializeObject<List<Categories>>(apiData);
            return View(categorie);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categories ca)
        {
            string apiURL = "https://localhost:7149/api/Categorie/PostCategory";
            var content = new StringContent(JsonConvert.SerializeObject(ca), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCategorie", "Categorie");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> CategorieDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Categorie/GetCategory/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var categorie = JsonConvert.DeserializeObject<Categories>(apiData);
            return View(categorie);
        }
        public async Task<IActionResult> EditCategorie(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Categorie/GetCategory/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var categorie = JsonConvert.DeserializeObject<Categories>(apiData);
            return View(categorie);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategorie(Guid id, Categories ca)
        {
            string apiURL = $"https://localhost:7149/api/Categorie/UpdateCategory/{id}?name={ca.CategoryName}";
            var content = new StringContent(JsonConvert.SerializeObject(ca), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCategorie", "Categorie");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategorie(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Categorie/DeleteCategory/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCategorie", "Categorie");
            }
            return BadRequest();
        }
    }
}
