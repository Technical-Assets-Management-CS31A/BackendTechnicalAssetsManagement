using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBarcodeAddRfidToArchives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---------------------------------------------------------------
            // 1. Drop Barcode columns from Items
            // ---------------------------------------------------------------
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BarcodeImage",
                table: "Items");

            // ---------------------------------------------------------------
            // 2. Drop Barcode columns from LentItems
            // ---------------------------------------------------------------
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "BarcodeImage",
                table: "LentItems");

            // ---------------------------------------------------------------
            // 3. Drop Barcode columns from ArchiveItems
            // ---------------------------------------------------------------
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "ArchiveItems");

            migrationBuilder.DropColumn(
                name: "BarcodeImage",
                table: "ArchiveItems");

            // ---------------------------------------------------------------
            // 4. Drop Barcode columns from ArchiveLentItems
            // ---------------------------------------------------------------
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "BarcodeImage",
                table: "ArchiveLentItems");

            // ---------------------------------------------------------------
            // 5. Add RfidUid to Items (if not already present via .cmd script)
            //    Using IF NOT EXISTS guard via raw SQL for safety.
            // ---------------------------------------------------------------
            migrationBuilder.Sql(@"
                ALTER TABLE ""Items""
                ADD COLUMN IF NOT EXISTS ""RfidUid"" text NULL;
            ");

            // ---------------------------------------------------------------
            // 6. Add unique index on Items.RfidUid (partial — only non-null rows)
            // ---------------------------------------------------------------
            migrationBuilder.Sql(@"
                CREATE UNIQUE INDEX IF NOT EXISTS ""IX_Items_RfidUid""
                ON ""Items"" (""RfidUid"")
                WHERE ""RfidUid"" IS NOT NULL;
            ");

            // ---------------------------------------------------------------
            // 7. Add Location to Items (if not already present via .cmd script)
            // ---------------------------------------------------------------
            migrationBuilder.Sql(@"
                ALTER TABLE ""Items""
                ADD COLUMN IF NOT EXISTS ""Location"" text NULL;
            ");

            // ---------------------------------------------------------------
            // 8. Add TagUid and StudentRfid to LentItems (if not already present)
            // ---------------------------------------------------------------
            migrationBuilder.Sql(@"
                ALTER TABLE ""LentItems""
                ADD COLUMN IF NOT EXISTS ""TagUid"" text NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""LentItems""
                ADD COLUMN IF NOT EXISTS ""StudentRfid"" text NULL;
            ");

            // ---------------------------------------------------------------
            // 9. Add RfidUid to ArchiveItems (new — fixes archive data gap)
            // ---------------------------------------------------------------
            migrationBuilder.AddColumn<string>(
                name: "RfidUid",
                table: "ArchiveItems",
                type: "text",
                nullable: true);

            // ---------------------------------------------------------------
            // 10. Add TagUid and StudentRfid to ArchiveLentItems (new — fixes archive data gap)
            // ---------------------------------------------------------------
            migrationBuilder.AddColumn<string>(
                name: "TagUid",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentRfid",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            // ---------------------------------------------------------------
            // 11. Add RfidUid to Students (if not already present via .cmd script)
            // ---------------------------------------------------------------
            migrationBuilder.Sql(@"
                ALTER TABLE ""Students""
                ADD COLUMN IF NOT EXISTS ""RfidUid"" text NULL;
            ");

            migrationBuilder.Sql(@"
                CREATE UNIQUE INDEX IF NOT EXISTS ""IX_Students_RfidUid""
                ON ""Students"" (""RfidUid"")
                WHERE ""RfidUid"" IS NOT NULL;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // ---------------------------------------------------------------
            // Reverse: restore Barcode columns
            // ---------------------------------------------------------------
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BarcodeImage",
                table: "Items",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BarcodeImage",
                table: "LentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "ArchiveItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BarcodeImage",
                table: "ArchiveItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BarcodeImage",
                table: "ArchiveLentItems",
                type: "bytea",
                nullable: true);

            // Reverse: drop RFID additions to archive tables
            migrationBuilder.DropColumn(name: "RfidUid", table: "ArchiveItems");
            migrationBuilder.DropColumn(name: "TagUid", table: "ArchiveLentItems");
            migrationBuilder.DropColumn(name: "StudentRfid", table: "ArchiveLentItems");

            // Reverse: drop RFID columns added to live tables (raw SQL — only if they exist)
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS ""IX_Items_RfidUid"";");
            migrationBuilder.Sql(@"ALTER TABLE ""Items"" DROP COLUMN IF EXISTS ""RfidUid"";");
            migrationBuilder.Sql(@"ALTER TABLE ""Items"" DROP COLUMN IF EXISTS ""Location"";");
            migrationBuilder.Sql(@"ALTER TABLE ""LentItems"" DROP COLUMN IF EXISTS ""TagUid"";");
            migrationBuilder.Sql(@"ALTER TABLE ""LentItems"" DROP COLUMN IF EXISTS ""StudentRfid"";");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS ""IX_Students_RfidUid"";");
            migrationBuilder.Sql(@"ALTER TABLE ""Students"" DROP COLUMN IF EXISTS ""RfidUid"";");
        }
    }
}
