using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class CartDetailController : Controller
    {
        private HttpClient _httpClient;
        public CartDetailController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllCartDetail()
        {
            string apiUrl = $"https://localhost:7149/api/CartDetail/GetAllCartDetail";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var cd = JsonConvert.DeserializeObject<List<CartDetail>>(apiData);
            return View(cd);
        }
        public async Task<IActionResult> CreateCartDetail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCartDetail(CartDetail cd)
        {
            string apiURL = $"https://localhost:7149/api/CartDetail/PostCartDetail?quantity={cd.Quantity}&price={cd.Price}&total={cd.ToTal}";

            var content = new StringContent(JsonConvert.SerializeObject(cd), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCartDetail", "CartDetail");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> CartDetailDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/CartDetail/GetCartDetailById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<CartDetail>(apiData);
            return View(r);
        }
        public async Task<IActionResult> EditCartDetail(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/CartDetail/GetCartDetailById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<CartDetail>(apiData);
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> EditCartDetail(Guid id, CartDetail cd)
        {
            string apiURL = $"https://localhost:7149/api/CartDetail/PutCartDetail/{id}?quantity={cd.Quantity}&price={cd.Price}&total={cd.ToTal}";
            var content = new StringContent(JsonConvert.SerializeObject(cd), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCartDetail", "CartDetail");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCartDetail(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/CartDetail/DeleteCartDetail/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCartDetail", "CartDetail");
            }
            return BadRequest();
        }
    }
}
