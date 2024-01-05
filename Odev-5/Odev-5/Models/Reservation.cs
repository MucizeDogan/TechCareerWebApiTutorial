using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerOdev5.Odev_5.Models {
    public class Reservation : BaseModel {
        public DateTime EntryReservation { get; set; }
        public DateTime ExitReservation { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
