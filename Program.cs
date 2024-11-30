using _22._10.Models;

namespace _22._10
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ProductService();

            // Добавление товара
            var product = new Product
            {
                Name = "Laptop",
                Description = "High performance laptop",
                Price = 1000,
                Quantity = 10
            };
            service.AddProduct(product);

            // Обновление товара
            var updatedProduct = service.GetProduct(product.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Price = 1200;
                service.UpdateProduct(updatedProduct);
            }

            // Вывод всех товаров
            foreach (var p in service.GetAllProducts())
            {
                Console.WriteLine($"{p.Name} - {p.Price}$");
            }
        }
    }
}
