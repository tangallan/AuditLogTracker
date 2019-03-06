namespace AuditLogConsoleApp.Models
{
    public class Product
    {
        public Product()
        {
        }

        public string ProductNumber { get; set; }
        public decimal ProductCost { get; set; }
        public string Sku { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
