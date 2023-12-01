using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project_it3045c.Migrations
{
    /// <inheritdoc />
    public partial class TeamMemberChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "TeamMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollegeProgram",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearInProgram",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "CollegeProgram",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "YearInProgram",
                table: "TeamMembers");
        }
    }
}
