namespace Catalog.API.RequestModels.CommandRequestModels
{
    public class SaveProductRequestModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price{get;set;}
    }
}