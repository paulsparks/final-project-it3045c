using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project_it3045c.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemBrand",
                table: "StoreItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "StoreItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemBrand",
                table: "StoreItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StoreItems");
        }
    }
}
