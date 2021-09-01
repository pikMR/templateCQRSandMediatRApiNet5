namespace Catalog.API.Contracts.CommandHandlers
{
using System.Threading.Tasks;
using Catalog.API.RequestModels.CommandRequestModels;
    public interface ISaveProductCommandHandler
    {
         Task<int> SaveAsync(SaveProductRequestModel requestModel);
    }
}