using Microsoft.AspNetCore.Mvc;
using New_API_Work.Models;
using System.Diagnostics;

namespace New_API_Work.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()

        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://the-cocktail-db.p.rapidapi.com/search.php?s={drinkType}"),
                Headers =
    {
            { "X-RapidAPI-Key", "apikey" },
            { "X-RapidAPI-Host", "the-cocktail-db.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Drinks drinkType)
        {
        string IdDrink = drinkType.IdDrink;
        string StrDrink = drinkType.StrDrink;
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}