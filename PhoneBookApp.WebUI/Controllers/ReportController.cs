using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.WebUI.Models;

namespace PhoneBookApp.WebUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> LocationChart()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Reports/GetRegisteredLocationCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReportDataModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> UserChart()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Reports/GetRegisteredUserCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReportDataModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PhoneChart()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Reports/GetRegisteredPhoneCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReportDataModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}