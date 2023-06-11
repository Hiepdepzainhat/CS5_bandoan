using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class NationalController : Controller
    {
        private HttpClient _httpClient;
        public NationalController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllNational()
        {
            string apiUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var nationals = JsonConvert.DeserializeObject<List<National>>(apiData);
            return View(nationals);
        }
        public async Task<IActionResult> CreateNational()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNational(National na)
        {
            string apiURL = $"https://localhost:7149/api/Nationals/PostNational?nationalName={na.NationalName}";
            var content = new StringContent(JsonConvert.SerializeObject(na), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNational", "National");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> NationalDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Nationals/GetNationalById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var national = JsonConvert.DeserializeObject<National>(apiData);
            return View(national);
        }
        public async Task<IActionResult> EditNational(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Nationals/GetNationalById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var national = JsonConvert.DeserializeObject<National>(apiData);
            return View(national);
        }
        [HttpPost]
        public async Task<IActionResult> EditNational(Guid id, National na)
        {
            string apiURL = $"https://localhost:7149/api/Nationals/UpdateNational/{id}?name={na.NationalName}";
            var content = new StringContent(JsonConvert.SerializeObject(na), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNational", "National");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNational(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Nationals/DeleteNational/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNational", "National");
            }
            return BadRequest();
        }
    }
}
