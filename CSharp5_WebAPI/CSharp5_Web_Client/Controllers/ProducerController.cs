using CSharp5_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSharp5_Web_Client.Controllers
{
    public class ProducerController : Controller
    {
        private readonly HttpClient _httpClient;
        public ProducerController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducer()
        {
            string apiUrl = "https://localhost:7149/api/producer/GetProducers";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var producers = JsonConvert.DeserializeObject<List<Producer>>(apiData);
            return View(producers); 
        }
        [HttpGet]

        public async Task<IActionResult> ProducerDetail(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/producer/GetProducerById/{id}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var producers = JsonConvert.DeserializeObject<Producer>(apiData);
            return View(producers);
        }
        public async Task<IActionResult> AddProducer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProducer(Producer producer)
        {
            var producerJson = JsonConvert.SerializeObject(producer);
            var stringContent = new StringContent(producerJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7149/api/producer/PostProducer", stringContent);
            return RedirectToAction("GetProducer");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProducer(Guid id)
        {
            string apiUrl = $"https://localhost:7149/api/producer/GetProducerById/{id}";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var producers = JsonConvert.DeserializeObject<Producer>(apiData);
            return View(producers);
        }
        public async Task<IActionResult> UpdateProducer(Producer producer)
        {
            var producerJson = JsonConvert.SerializeObject(producer);
            var stringContent = new StringContent(producerJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7149/api/producer/PutProducer/{producer.ProducerID}", stringContent);
            return RedirectToAction("GetProducer");
        }
        public async Task<IActionResult> DeleteProducer(Guid id)
        {
            var producerJson = JsonConvert.SerializeObject(id);
            var response = await _httpClient.DeleteAsync($"https://localhost:7149/api/producer/DeleteProducer/{id}");
            return RedirectToAction("GetProducer");
        }
    }
}
