using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.HSSF.Record.Chart;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class ChefController : Controller
    {
        private HttpClient _httpClient;
        public ChefController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllChef()
        {
            string apiUrl = "https://localhost:7149/api/Chef/GetAllChef";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var chefs = JsonConvert.DeserializeObject<List<Chef>>(apiData);
            return View(chefs);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Create(Chef chef)
        {
            string apiUrl = "https://localhost:7149/api/Chef/PostChef";
            var content = new StringContent(JsonConvert.SerializeObject(chef), Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync(apiUrl, content);
            if (reponse.IsSuccessStatusCode) 
            {
                return RedirectToAction("ShowAllChef", "Chef");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ChefDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Chef/GetChef/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var chefs = JsonConvert.DeserializeObject<Chef>(apiData);
            return View(chefs);
        }
        public async Task<IActionResult> EditChef(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Chef/GetChef/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var chefs = JsonConvert.DeserializeObject<Chef>(apiData);
            return View(chefs);
        }
        [HttpPost]
        public async Task<IActionResult> EditChef(Guid id, Chef chef)
        {
            string apiURL = $"https://localhost:7149/api/Chef/UpdateChef/{id}";
            var content = new StringContent(JsonConvert.SerializeObject(chef), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllChef", "Chef");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteChef(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Chef/DeleteChef/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllChef", "Chef");
            }
            return BadRequest();
        }
    }
}
