using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationAfterFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pessoas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pessoas");

        }
    }
}
