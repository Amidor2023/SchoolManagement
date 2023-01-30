using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Emploi.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Teacher",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Student",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Teacher",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Student",
                newName: "UserName");
        }
    }
}
