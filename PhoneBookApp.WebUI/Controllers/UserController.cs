using System.Text;
using Newtonsoft.Json;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.Business.ValidationRules.FluentValidation;

namespace PhoneBookApp.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Users/GetUserList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<User>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5119/api/Users/GetByUser/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<User>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            UserValidator userValidator = new();
            ValidationResult validationResult = userValidator.Validate(user);
            if (validationResult.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(user);
                StringContent content = new(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5119/api/Users/Add", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5119/api/Users/GetByUser/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<User>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            UserValidator userValidator = new();
            ValidationResult validationResult = userValidator.Validate(user);
            if (validationResult.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(user);
                StringContent content = new(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5119/api/Users/Update", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5119/api/Users/Delete/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Deleted", "User");
            }
            return View();
        }

        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var user = await client.GetAsync($"http://localhost:5119/api/Users/GetByUser/{id}");
            if (user.IsSuccessStatusCode)
            {
                var jsonData = JsonConvert.SerializeObject(user);
                StringContent content = new(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync($"http://localhost:5119/api/Users/ChangeStatus/{id}", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View();
        }

        public async Task<IActionResult> Deleted()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5119/api/Users/GetDeletedUserList");
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