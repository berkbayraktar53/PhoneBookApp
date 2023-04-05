using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.WebUI.Models;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region AddedUserCount()
            var addedUserCountMessage = await client.GetAsync("http://localhost:5119/api/Users/GetUserList");
            if (addedUserCountMessage.IsSuccessStatusCode)
            {
                var jsonData = await addedUserCountMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<User>>(jsonData);
                ViewBag.totalUserCount = values.Count;
            }
            #endregion
            #region AddedLocationCount()
            var addedLocationCountMessage = await client.GetAsync("http://localhost:5119/api/Reports/GetRegisteredLocationCount");
            if (addedLocationCountMessage.IsSuccessStatusCode)
            {
                var jsonData = await addedLocationCountMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReportDataModel>>(jsonData);
                ViewBag.totalLocationCount = values.Count;
            }
            #endregion
            #region AddedPhoneCount()
            var addedPhoneCountMessage = await client.GetAsync("http://localhost:5119/api/Reports/GetRegisteredPhoneCount");
            if (addedPhoneCountMessage.IsSuccessStatusCode)
            {
                var jsonData = await addedPhoneCountMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReportDataModel>>(jsonData);
                ViewBag.totalPhoneCount = values.Count;
            }
            #endregion
            #region DeletedUserCount()
            var deletedUserCountMessage = await client.GetAsync("http://localhost:5119/api/Users/GetDeletedUserList");
            if (deletedUserCountMessage.IsSuccessStatusCode)
            {
                var jsonData = await deletedUserCountMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<User>>(jsonData);
                ViewBag.totalDeletedUserCount = values.Count;
            }
            #endregion
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Users/Get5LastAddedUsers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<User>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}