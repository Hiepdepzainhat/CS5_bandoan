using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class ComboController : Controller
    {
        private HttpClient _httpClient;
        public ComboController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllCombo()
        {
            string apiUrl = $"https://localhost:7149/api/Combo/GetAllCombo";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var combos = JsonConvert.DeserializeObject<List<Combo>>(apiData);
            return View(combos);
        }
        public async Task<IActionResult> CreateCombo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCombo(Combo cb,IFormFile imageFile)
        {
            //string apiURL = $"https://localhost:7149/api/Combo/PostCombo?name={cb.ComboName}&img{cb.ImgCombo}&price={cb.Price}&status{cb.Status}";
            string apiURL = $"https://localhost:7149/api/Combo/PostCombo";
			if (imageFile != null && imageFile.Length > 0)
			{
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
				var stream = new FileStream(path, FileMode.Create);
				imageFile.CopyTo(stream);
				cb.ImgCombo = imageFile.FileName;
			}


			var content = new StringContent(JsonConvert.SerializeObject(cb), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCombo", "Combo");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ComboDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Combo/GetCombo/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var combos = JsonConvert.DeserializeObject<Combo>(apiData);
            return View(combos);
        }
        public async Task<IActionResult> EditCombo(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Combo/GetCombo/{id}";

            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var combos = JsonConvert.DeserializeObject<Combo>(apiData);
            return View(combos);
        }
        [HttpPost]
        public async Task<IActionResult> EditCombo(Guid id, Combo cb)
        {
            string apiURL = $"https://localhost:7149/api/Combo/PutCombo/{id}?name={cb.ComboName}&img{cb.ImgCombo}&price={cb.Price}&status{cb.Status}";
 

            var content = new StringContent(JsonConvert.SerializeObject(cb), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCombo", "Combo");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCombo(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Combo/DeleteCombo/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCombo", "Combo");
            }
            return BadRequest();
        }
    }
}
