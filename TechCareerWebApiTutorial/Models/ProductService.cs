namespace TechCareerWebApiTutorial.Models {
    public class ProductService {
        public static List<Product> GetProducts() {
            var products = new List<Product>();
            products.Add(new Product("Buzdolabı",1,1000));
            products.Add(new Product("Çamaşı Makinesi", 2, 500));
            products.Add(new Product("Bilgisayar", 3, 1000));
            products.Add(new Product("Klavye", 3, 100));

            return products;
        }
    }
}
