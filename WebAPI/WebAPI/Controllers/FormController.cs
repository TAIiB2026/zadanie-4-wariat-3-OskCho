using Contracts;
using Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : Controller
    {
        private readonly IFormSubmitInterface formSubmitInterface;

        public FormController(IFormSubmitInterface formSubmitInterface)
        {
            this.formSubmitInterface = formSubmitInterface;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DataDTO dataDTO)
        {
            bool response = await formSubmitInterface.AddDataAsync(dataDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] DataDTO dataDTO)
        {
            bool response = await formSubmitInterface.EditDataAsync(id, dataDTO);
            if (!response)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}