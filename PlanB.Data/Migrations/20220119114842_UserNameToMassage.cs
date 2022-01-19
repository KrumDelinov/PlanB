using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanB.Data.Migrations
{
    public partial class UserNameToMassage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Massages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Massages");
        }
    }
}
