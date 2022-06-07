using Microsoft.AspNetCore.Mvc;

namespace ITSector.Entrevista.Web.Controllers
{
    [Route("[controller]")]
    public class EstatisticaController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View(0F);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(int chutes)
        {
            float result = 0;
            using (var client = new HttpClient())
            {
                //Endpoint fixo apenas para facilidade no teste. API ficaria criptografada no appsettings.
                string endpoint = $"https://localhost:7170/api/Estatistica/CalculaProbabilidadeDeGol/{chutes}";
                using var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<float>().GetAwaiter().GetResult();
                }
            }

            return View(Convert.ToSingle(result));
        }
    }
}
