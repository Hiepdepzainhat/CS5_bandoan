using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class ComboItemController : Controller
    {
        private HttpClient _httpClient;
        public ComboItemController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllComboItem()
        {
            string apiUrl = $"https://localhost:7149/api/ComboItem/GetAllComboItem";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var comboItem = JsonConvert.DeserializeObject<List<ComboItems>>(apiData);
            return View(comboItem);
        }
        public async Task<IActionResult> CreateComboItem()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComboItem(ComboItems cbi)
        {
            string apiURL = $"https://localhost:7149/api/ComboItem/PostComboItem?price={cbi.Price}";

            var content = new StringContent(JsonConvert.SerializeObject(cbi), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllComboItem", "ComboItem");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ComboItemDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/ComboItem/GetComboItem/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var comboItem = JsonConvert.DeserializeObject<ComboItems>(apiData);
            return View(comboItem);
        }
        public async Task<IActionResult> EditComboItem(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/ComboItem/GetComboItem/{id}";

            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var comboItem = JsonConvert.DeserializeObject<ComboItems>(apiData);
            return View(comboItem);
        }
        [HttpPost]
        public async Task<IActionResult> EditComboItem(Guid id, ComboItems cbi)
        {
            string apiURL = $"https://localhost:7149/api/ComboItem/PutComboItem/{id}?price={cbi.Price}";


            var content = new StringContent(JsonConvert.SerializeObject(cbi), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllComboItem", "ComboItem");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteComboItem(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/ComboItem/DeleteComboItem/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllComboItem", "ComboItem");
            }
            return BadRequest();
        }
    }
}
