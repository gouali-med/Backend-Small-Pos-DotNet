namespace GestionCommercialeServices.DTO
{
    public class ProductDTO
    {
        public string? BarCode { get; set; }
        public IFormFile Picture { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int UniteOfSaleID { get; set; }
        public float PurchasPrice { get; set; }
        public float Price { get; set; }
        public float? StockAlerte { get; set; }
    }
}
