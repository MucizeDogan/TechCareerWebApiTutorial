namespace TechCareerWebApiTutorial.Models {
    public class Product {

        public Product(string name, int id, double unitPrice,int cID, string cName) {
            this.Name = name;
            this.ID = id;
            this.UnitPrice = unitPrice;
            this.category.ID = cID;
            this.category.Name = cName;
        }

        public int ID{ get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public Category category{ get; set; }
    }
}
