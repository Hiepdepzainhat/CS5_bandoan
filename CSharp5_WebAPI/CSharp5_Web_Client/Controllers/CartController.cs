using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class CartController : Controller
    {
        private HttpClient _httpClient;
        public CartController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllCart()
        {
            string apiUrlUser = $"https://localhost:7149/api/User/GetAllUser";
            var httpClientUser = new HttpClient();
            var reponseUser = await httpClientUser.GetAsync(apiUrlUser);
            string apiDataUser = await reponseUser.Content.ReadAsStringAsync();
            var listUser = JsonConvert.DeserializeObject<List<User>>(apiDataUser);
            ViewBag.Users = listUser;

            string apiUrl = $"https://localhost:7149/api/Cart/GetAllCart";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var c = JsonConvert.DeserializeObject<List<Cart>>(apiData);
            return View(c);
        }
        
        [HttpGet]
        public async Task<IActionResult> CartDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Cart/GetCartById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<Cart>(apiData);
            return View(r);
        }
        public async Task<IActionResult> EditCart(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Cart/GetCartById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<Cart>(apiData);
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> EditCart(Guid id, Cart c)
        {
            string apiURL = $"https://localhost:7149/api/Cart/PutCart/{id}?description={c.Desciption}&status={c.Status}";
            var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCart", "Cart");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Cart/DeleteCart/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCart", "Cart");
            }
            return BadRequest();
        }
    }
}
