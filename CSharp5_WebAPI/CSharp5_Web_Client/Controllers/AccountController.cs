using Microsoft.AspNetCore.Mvc;

namespace CSharp5_Web_Client.Controllers
{
    public class AccountController : Controller
    {
        HttpClient _httpclient;
        public AccountController()
        {
            _httpclient = new HttpClient();
        }
    }
}
