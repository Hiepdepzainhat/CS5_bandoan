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
            string apiUrl = $"https://localhost:7149/api/User/GetAllUser";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(user);
        }
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User r,Cart c)
        {
            string apiURL = $"https://localhost:7149/api/User/PostUser?Name={r.Name}&UserName={r.UserName}&PassWord={r.PassWord}&PhoneNumber={r.PhoneNumber}&Address={r.Address}&DateOfBirth={r.DateOfBirth}&Sex={r.Sex}&ImgUser={r.ImgUser}";
            

            var content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            string cartURL = $"https://localhost:7149/api/Cart/PostCart?userId={r.UserID}&description={c.Desciption}&status={1}";
            var Cartcontent = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            var Cartresponse = await _httpClient.PostAsync(apiURL, content);
            if (!response.IsSuccessStatusCode  && !Cartresponse.IsSuccessStatusCode)
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
