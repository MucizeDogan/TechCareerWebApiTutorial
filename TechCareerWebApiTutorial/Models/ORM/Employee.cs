namespace TechCareerWebApiTutorial.Models.ORM {
    public class Employee {
        public int ID{ get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? adress{ get; set; }
        public DateTime? birthDate{ get; set; }
        public string? city{ get; set; }
        public DateTime addDate { get; set; }
    }
}
