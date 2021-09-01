namespace Catalog.API.Handlers.CommandHandlers
{
using System.Threading.Tasks;
using Catalog.API.Contracts.CommandHandlers;
using Catalog.API.RequestModels.CommandRequestModels;
using Catalog.API.Domain.Model;
using Catalog.API.Infrastructure;
    public class SaveProductCommandHandler : ISaveProductCommandHandler
    {
        public readonly CatalogContext _catalogContext;
        public SaveProductCommandHandler(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
 
        public async Task<int> SaveAsync(SaveProductRequestModel requestModel)
        {
            var newProducts = new Products
            {
                Description = requestModel.Description,
                Manufacturer = requestModel.Manufacturer,
                Name = requestModel.Name,
                Price = requestModel.Price
            };
 
            _catalogContext.Products.Add(newProducts);
            await _catalogContext.SaveChangesAsync();
            return newProducts.ProductId;
        }
    }
}