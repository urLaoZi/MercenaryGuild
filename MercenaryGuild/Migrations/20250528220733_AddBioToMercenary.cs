using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercenaryGuild.Migrations
{
    /// <inheritdoc />
    public partial class AddBioToMercenary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Quests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Mercenaries",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Mercenaries");
        }
    }
}
