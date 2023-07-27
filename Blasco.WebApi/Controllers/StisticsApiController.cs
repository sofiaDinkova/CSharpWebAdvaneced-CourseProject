using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blasco.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StisticsApiController : ControllerBase
    {
        private readonly IProductService productService;

        public StisticsApiController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatisticts()
        {
            try
            {
                StatisticsServiceModel serviceModel = await this.productService.GetStatisticsAsync();

                return this.Ok(serviceModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
