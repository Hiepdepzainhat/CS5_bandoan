using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class RoleController : Controller
    {
        private HttpClient _httpClient;
        public RoleController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllRole()
        {
            string apiUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return View(roles);
        }
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(Role r)
        {
            string apiURL = $"https://localhost:7149/api/Role/PostRole?roleName={r.RoleName}";
            var content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllRole", "Role");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> RoleDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Role/GetRole/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<Role>(apiData);
            return View(roles);
        }
        public async Task<IActionResult> EditRole(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Role/GetRole/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<Role>(apiData);
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(Guid id, Role role)
        {
            string apiURL = $"https://localhost:7149/api/Role/PutRole/{id}?name={role.RoleName}";
            var content = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllRole","Role");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Role/DeleteRole/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllRole", "Role");
            }
            return BadRequest();
        }
    }
}
