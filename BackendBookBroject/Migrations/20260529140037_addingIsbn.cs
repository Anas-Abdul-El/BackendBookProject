using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBookBroject.Migrations
{
    /// <inheritdoc />
    public partial class addingIsbn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBarrowed",
                table: "Books",
                newName: "IsBorrowed");

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IsBorrowed",
                table: "Books",
                newName: "IsBarrowed");
        }
    }
}
