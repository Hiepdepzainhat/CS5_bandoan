using CSharp5_Share.Models;
using CSharp5_Web_Client.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class AccountController : Controller
    {
        HttpClient _httpclient;
        public AccountController()
        {
            _httpclient = new HttpClient();
        }

        public IActionResult Login() // Mở Form
        {
            return View();
        }
        public async Task<IActionResult> SignUp()
        {
            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var NationalUrl = $"https://localhost:7149/api/Nationals/GetAllNational";
            var httpClientNational = new HttpClient();
            var reponseNational = await httpClientNational.GetAsync(NationalUrl);
            string apiDataNational = await reponseNational.Content.ReadAsStringAsync();
            var listNational = JsonConvert.DeserializeObject<List<National>>(apiDataNational);
            ViewBag.Nationals = listNational;

            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole); // lấy ra tất cả các role
            var roleAdmin = listRole.FirstOrDefault(p => p.RoleName == "Admin"); // lấy roleId của admin 
            var roleUser = listRole.FirstOrDefault(p => p.RoleName == "Customer");// lấy roleId của customer 

            string apiUrl = $"https://localhost:7149/api/User/GetAllUser";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var Listusers = JsonConvert.DeserializeObject<List<User>>(apiData);

            var user = Listusers.FirstOrDefault(p => p.UserName == userName && p.PassWord == password);
            if (user != null)
            {
                HttpContext.Session.SetString("NameUser", user.UserName);
                HttpContext.Session.SetString("IdUser", Convert.ToString(user.UserID));
                if (user.RoleID == roleAdmin.RoleID)
                {
                    return RedirectToAction("ShowAllProducts", "Product");
                }
                else if (user.RoleID == roleUser.RoleID)
                {
                    return RedirectToAction("ShowAllProductsHome", "Product");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        /*[HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel singup, IFormFile imageFile)
        {
            singup.UserID = Guid.NewGuid();
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"
                    , imageFile.FileName); // abc/wwwroot/images/xxx.png
                var stream = new FileStream(path, FileMode.Create);  // tạo 1 filestream để tạo mới
                imageFile.CopyTo(stream);//copy ảnh vừa đc chọn vô stream đó
                                         // gán lại giá trị hình ảnh(lúc này đã nằm trong root cho thuộc tính description)
                singup.ImgUser = imageFile.FileName;
            }

            var RoleUrl = $"https://localhost:7149/api/Role/GetAllRole";
            var httpClientRole = new HttpClient();
            var reponseRole = await httpClientRole.GetAsync(RoleUrl);
            string apiDataRole = await reponseRole.Content.ReadAsStringAsync();
            var listRole = JsonConvert.DeserializeObject<List<Role>>(apiDataRole); // lấy ra tất cả các role
            var roleAdmin = listRole.FirstOrDefault(p => p.RoleName == "Admin"); // lấy roleId của admin 
            var roleUser = listRole.FirstOrDefault(p => p.RoleName == "Customer");// lấy roleId của customer 

            string apiUrl = $"https://localhost:7149/api/User/GetAllUser";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var Listusers = JsonConvert.DeserializeObject<List<User>>(apiData); // lấy tất cả User ra
            if (Listusers.Any(p => p.UserName == singup.UserName))  // nếu UserName đã tồn tại --> trả về trang đăng nhập
            {
                return RedirectToAction("Login", "Account");
            }
            else // nếu k thì gán thuộc tính
            {
                var user = new User
                {
                    UserID = singup.UserID,
                    RoleID = roleUser.RoleID,
                    NationalID = singup.NationalID,
                    Name = singup.Name,
                    UserName = singup.UserName,
                    PassWord = singup.PassWord,
                    ImgUser = singup.ImgUser,
                    PhoneNumber = singup.PhoneNumber,
                    Address = singup.Address,
                    DateOfBirth = singup.DateOfBirth
                };
                string apiURLCreateUser = $"https://localhost:7149/api/User/PostUser";
                var contentCreateUser = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var responseCreateUser = await _httpclient.PostAsync(apiURLCreateUser, contentCreateUser);
                if (responseCreateUser.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllUser", "User");
                }
                else
                {
                    return BadRequest();
                }
            }
        }*/
    }
}
