namespace TechCareerWebApiTutorial.Models {
    public class Product {

        public Product(string name, int id, double unitPrice) {
            this.Name = name;
            this.ID = id;
            this.UnitPrice = unitPrice;
        }

        public int ID{ get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public Category category{ get; set; }
    }
}
