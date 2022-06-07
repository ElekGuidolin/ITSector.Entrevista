using Microsoft.AspNetCore.Mvc;

namespace ITSector.Entrevista.Web.Controllers
{
    [Route("[controller]")]
    public class AlteraCaseLetrasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Alterar(string original)
        {
            string caseInvertido = await Task.Run(() =>
            {
                return new string(original.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
            });

            return View("Index", caseInvertido);
        }
    }
}
