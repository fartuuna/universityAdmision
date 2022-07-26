using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAdmisionApplcation.Migrations
{
    public partial class fimecolumnmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwor",
                table: "AddmissionOficer",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AddmissionOficer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AddmissionOficer",
                newName: "Passwor");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AddmissionOficer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
