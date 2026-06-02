using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly IGetDataInterface getDataInterface;

        public DataController(IGetDataInterface getDataInterface)
        {
            this.getDataInterface = getDataInterface;
        }

        // Metoda dla widoku "Filmy" w stylu wykładowcy
        [HttpGet("movies")]
        public async Task<IActionResult> GetMoviesAsync()
        {
            var response = await getDataInterface.GetMoviesAsync();
            return Ok(response);
        }

        // Metoda dla widoku "Formularz" w stylu wykładowcy
        [HttpGet("form")]
        public async Task<IActionResult> GetFormDataAsync()
        {
            var response = await getDataInterface.GetFormDataAsync();
            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}