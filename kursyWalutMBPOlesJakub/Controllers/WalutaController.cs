using kursyWalutMBPOlesJakub.Models;
using kursyWalutMBPOlesJakub.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace kursyWalutMBPOlesJakub.Controllers
{
    [ApiController]
    public class WalutaController : Controller
    {
        IWalutaService _walutaService;
        IConfiguration _config;

        public WalutaController(IConfiguration config, IWalutaService walutaService)
        {
            _walutaService = walutaService;
            _config = config;
        }

        [Route("currency/{date}/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetCurrency(string date, string code)
        {
            string nbpUrl = _walutaService.buildUrlToApi(_config.GetValue<string>("NBPUri:mainNBPUri"), date, code);
            var serializedWaluta = new WalutaJSONSerializer();

            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(nbpUrl);
                    serializedWaluta = JsonConvert.DeserializeObject<WalutaJSONSerializer>(json);
                }
                catch (Exception)
                {
                    throw;
                    return NotFound();
                }
            }
            var waluta = _walutaService.fromJSONtypeToObject(serializedWaluta);
            _walutaService.SaveWaluta(waluta);
            return Ok(waluta);
        }
    }
}
