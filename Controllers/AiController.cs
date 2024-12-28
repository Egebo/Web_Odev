using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_Odev.Services; // ReplicateService

namespace Web_Odev.Controllers
{
    public class AiController : Controller
    {
        private readonly ReplicateService _replicateService;

        public AiController(ReplicateService replicateService)
        {
            _replicateService = replicateService;
        }

        // Index Action'ı ekleyin
        public IActionResult Index()
        {
            return View(); // Index.cshtml sayfasını render edecektir
        }

        // GenerateImage Action'ı
        [HttpPost]
        public async Task<IActionResult> GenerateImage(string modelInput)
        {
            var result = await _replicateService.GenerateImageAsync(modelInput);

            var responseJson = JsonSerializer.Deserialize<JsonElement>(result);
            var imageUrl = responseJson.GetProperty("output")[0].GetString();

            return View("Result", imageUrl); // Sonucu gösteren View'a yönlendirme
        }
    }
}
