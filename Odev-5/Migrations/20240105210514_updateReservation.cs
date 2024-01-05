using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odev_5.Migrations
{
    public partial class updateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationEndDate",
                table: "Reservation",
                newName: "ExitReservation");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservation",
                newName: "EntryReservation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExitReservation",
                table: "Reservation",
                newName: "ReservationEndDate");

            migrationBuilder.RenameColumn(
                name: "EntryReservation",
                table: "Reservation",
                newName: "ReservationDate");
        }
    }
}
