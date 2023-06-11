using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class ProductController : Controller
    {
        HttpClient _httpClient;
        public ProductController()
        {
            _httpClient = new HttpClient();  
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllProducts()
        {
            string apiUrl = $"https://localhost:7149/api/Products/GetAllProducts";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Products>>(apiData);
            return View(products);
        }
        public async Task<IActionResult> CreateProducts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProducts(Products p)
        {
            string apiURL = $"https://localhost:7149/api/Products/PostProducts?productName={p.ProductName}" +
                $"?quantity={p.Quantity}?EntryPrice={p.EntryPrice}?EntryPrice={p.EntryPrice}?DateOfManufacture={p.DateOfManufacture}" +
                $"?Expired={p.Expired}?EntryPrice={p.EntryPrice}?ImPortDate={p.ImPortDate}?Price={p.Price}" +
                $"?Status={p.Status}?Desciption={p.Desciption}";
            var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllProducts", "Products");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ProductsDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/Products/GetProductsById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Products>(apiData);
            return View(products);
        }
        public async Task<IActionResult> EditProducts(Guid id)
        {
            string apiURL = $"https://localhost:7149/api/Products/GetProductsById/{id}";
            var response = await _httpClient.GetAsync(apiURL);
            var apiData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Products>(apiData);
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> EditProducts(Guid id, Products p)
        {
            string apiURL = $"https://localhost:7149/api/Products/UpdateProducts/{id}productName={p.ProductName}" +
                $"?quantity={p.Quantity}?EntryPrice={p.EntryPrice}?EntryPrice={p.EntryPrice}?DateOfManufacture={p.DateOfManufacture}" +
                $"?Expired={p.Expired}?EntryPrice={p.EntryPrice}?ImPortDate={p.ImPortDate}?Price={p.Price}" +
                $"?Status={p.Status}?Desciption={p.Desciption}";
            var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllProducts", "Products");
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
