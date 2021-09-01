namespace Catalog.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Catalog.API.Contracts.CommandHandlers;
    using System.Threading.Tasks;
    using Catalog.API.RequestModels.CommandRequestModels;

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISaveProductCommandHandler _saveProductCommandHandler;
        public ProductController(ISaveProductCommandHandler saveProductCommandHandler)
        {
            _saveProductCommandHandler = saveProductCommandHandler;
        }
 
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequestModel requestModel)
        {
            var result = await _saveProductCommandHandler.SaveAsync(requestModel);
            return Ok(result);
        }
    }
}