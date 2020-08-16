using Microsoft.EntityFrameworkCore.Migrations;

namespace KudVenkatEmploymentPortal.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Dept", "Email", "Name" },
                values: new object[] { 1, 2, "rama@gmail.com", "Rama" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
