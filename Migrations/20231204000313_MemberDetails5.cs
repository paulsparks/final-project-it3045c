using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project_it3045c.Migrations
{
    /// <inheritdoc />
    public partial class MemberDetails5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "MemberDetailsSet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteColor",
                table: "MemberDetailsSet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteDrink",
                table: "MemberDetailsSet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteTVShow",
                table: "MemberDetailsSet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "MemberDetailsSet");

            migrationBuilder.DropColumn(
                name: "FavoriteColor",
                table: "MemberDetailsSet");

            migrationBuilder.DropColumn(
                name: "FavoriteDrink",
                table: "MemberDetailsSet");

            migrationBuilder.DropColumn(
                name: "FavoriteTVShow",
                table: "MemberDetailsSet");
        }
    }
}
