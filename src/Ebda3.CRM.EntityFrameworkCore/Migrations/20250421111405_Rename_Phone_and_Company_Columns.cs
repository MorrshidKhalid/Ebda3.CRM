using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebda3.CRM.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Phone_and_Company_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Lead",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Camponey",
                table: "Lead",
                newName: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Lead",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Lead",
                newName: "Camponey");
        }
    }
}
