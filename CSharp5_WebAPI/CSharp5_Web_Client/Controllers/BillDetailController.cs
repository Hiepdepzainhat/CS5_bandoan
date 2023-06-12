using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class BillDetailController : Controller
    {
        private readonly HttpClient _httpClient;
        public BillDetailController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetBillDetail()
        {
            string apiUrl = "https://localhost:7149/api/billdetail/GetBillDetails";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var billdetails = JsonConvert.DeserializeObject<List<BillDetail>>(apiData);
            return View(billdetails);
        }
        public async Task<IActionResult> BillDetailDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/billdetail/GetBillDetailById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var billdetails = JsonConvert.DeserializeObject<BillDetail>(apiData);
            return View(billdetails);
        }
        public async Task<IActionResult> AddBillDetail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBillDetail(BillDetail billDetail)
        {
            var billDetailJson = JsonConvert.SerializeObject(billDetail);
            var stringContent = new StringContent(billDetailJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7149/api/billdetail/PostBillDetail", stringContent);
            return RedirectToAction("GetBillDetail");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBillDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/billdetail/GetBillDetailById/{id}";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var billDetails = JsonConvert.DeserializeObject<BillDetail>(apiData);
            return View(billDetails);
        }
        public async Task<IActionResult> UpdateBillDetail(BillDetail billDetail)
        {
            var billDetailJson = JsonConvert.SerializeObject(billDetail);
            var stringContent = new StringContent(billDetailJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7149/api/billdetail/PutBillDetail/{billDetail.BillDetailID}", stringContent);
            return RedirectToAction("GetBillDetail");
        }
        public async Task<IActionResult> DeleteBillDetail(Guid id)
        {
            var billDetailJson = JsonConvert.SerializeObject(id);
            var response = await _httpClient.DeleteAsync($"https://localhost:7149/api/billdetail/DeleteBillDetail/{id}");
            return RedirectToAction("GetBillDetail");
        }
    }
}
