using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class UserController : Controller
    {
        private HttpClient _httpClient;
        public UserController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllUser()
        {
            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole);
            ViewBag.Roles = listRole;

            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;

            string apiUrl = $"https://localhost:7149/api/User/GetAllUser";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole);
            ViewBag.Roless = listRole;

            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateUser(User r, IFormFile imageFile)
        {

            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole);
            ViewBag.Roless = listRole;

            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;

            string apiURL = $"https://localhost:7149/api/User/PostUser";
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                r.ImgUser = imageFile.FileName;
            }
            var content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser", "User");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UserDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/User/GetUser/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<User>(apiData);
            return View(r);
        }
        public async Task<IActionResult> EditUser(Guid id)
        {
            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole);
            ViewBag.Roles = listRole;

            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;

            string apiURL = $"https://localhost:7149/api/User/GetUser/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<User>(apiData);
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(Guid id, User user)
        {
            string apiURL = $"https://localhost:7149/api/User/PutUser/{id}?name={user.Name}&userName={user.UserName}&passWord={user.PassWord}&PhoneNumber={user.PhoneNumber}&Address={user.Address}&DateOfBirth={user.DateOfBirth}&Sex={user.Sex}&ImgUser={user.ImgUser}";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser", "User");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/User/DeleteUser/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser", "User");
            }
            return BadRequest();
        }
    }
}
