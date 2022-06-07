using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ITSector.Entrevista.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatisticaController : ControllerBase
    {
        [HttpGet("CalculaProbabilidadeDeGol/{chutes}")]
        public async Task<float> CalculaProbabilidadeDeGol(int chutes)
        {
            if (chutes == 0)
            {
                return 0;
            }

            var probabilidade = await Task.Run(() =>
            {
                float calculo = (chutes * 100 / 4);
                return calculo;
            });

            return probabilidade;
        }
    }
}
