using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class VoucherController : Controller
    {
        private HttpClient _httpClient;
        public VoucherController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllVoucher()
        {
            string apiUrl = $"https://localhost:7149/api/Voucher/GetAllVoucher";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var vouchers = JsonConvert.DeserializeObject<List<Voucher>>(apiData);
            return View(vouchers);
        }
        public async Task<IActionResult> CreateVoucher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVoucher(Voucher p)
        {
            string apiURL = $"https://localhost:7149/api/Voucher/PostVoucher?voucherName={p.VoucherName}?PercentageDiscount={p.PercentageDiscount}";
            var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher", "Voucher");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> VoucherDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Voucher/GetVoucherById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var voucher = JsonConvert.DeserializeObject<Voucher>(apiData);
            return View(voucher);
        }
        public async Task<IActionResult> EditVoucher(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Voucher/GetVoucherById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var national = JsonConvert.DeserializeObject<Voucher>(apiData);
            return View(national);
        }
        [HttpPost]
        public async Task<IActionResult> EditVoucher(Guid id, Voucher voucher)
        {
            string apiURL = $"https://localhost:7149/api/Voucher/UpdateVoucher/{id}?name={voucher.VoucherName}?percentageDiscount={voucher.PercentageDiscount}";
            var content = new StringContent(JsonConvert.SerializeObject(voucher), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher", "Voucher");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Voucher/DeleteVoucher/{id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher", "Voucher");
            }
            return BadRequest();
        }
    }
}
