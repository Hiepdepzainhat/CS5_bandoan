using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class BillController : Controller
    {
        private readonly HttpClient _httpClient;
        public BillController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetBill()
        {
            string apiUrl = "https://localhost:7149/api/bill/GetBills";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var bills = JsonConvert.DeserializeObject<List<Bill>>(apiData);
            return View(bills);
        }
        public async Task<IActionResult> BillDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/bill/GetBillById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var bills = JsonConvert.DeserializeObject<Bill>(apiData);
            return View(bills);
        }
        public async Task<IActionResult> AddBill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBill(Bill bill)
        {
            var billJson = JsonConvert.SerializeObject(bill);
            var stringContent = new StringContent(billJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7149/api/bill/PostBill", stringContent);
            return RedirectToAction("GetBill");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBill(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/bill/GetBillById/{id}";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var bills = JsonConvert.DeserializeObject<Bill>(apiData);
            return View(bills);
        }
        public async Task<IActionResult> UpdateBill(Bill bill)
        {
            var billJson = JsonConvert.SerializeObject(bill);
            var stringContent = new StringContent(billJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7149/api/bill/PutBill/{bill.BillID}", stringContent);
            return RedirectToAction("GetBill");
        }
        public async Task<IActionResult> DeleteBill(Guid id)
        {
            var billJson = JsonConvert.SerializeObject(id);
            var response = await _httpClient.DeleteAsync($"https://localhost:7149/api/bill/DeleteBill/{id}");
            return RedirectToAction("GetBill");
        }
    }
}
