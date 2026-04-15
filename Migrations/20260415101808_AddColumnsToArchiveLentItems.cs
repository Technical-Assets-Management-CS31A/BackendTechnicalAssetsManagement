using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToArchiveLentItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagUid",
                table: "ArchiveLentItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentRfid",
                table: "ArchiveLentItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedFor",
                table: "ArchiveLentItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagUid",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "StudentRfid",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "ReservedFor",
                table: "ArchiveLentItems");
        }
    }
}
