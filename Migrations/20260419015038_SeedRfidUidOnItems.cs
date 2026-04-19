using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedRfidUidOnItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000003"),
                column: "RfidUid",
                value: "RFID-ITEM-003");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000005"),
                column: "RfidUid",
                value: "RFID-ITEM-005");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000006"),
                column: "RfidUid",
                value: "RFID-ITEM-006");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$3soGz/bfe0/MV0R1jDmUK.lEHzjW/c3wG00JmTg8.svfq82pK3fSu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000003"),
                column: "RfidUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000005"),
                column: "RfidUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000006"),
                column: "RfidUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$UCFla1kKscisq5dD4ec8EOwJRMPQhqy28u9W3Rq2QSSzPJIxsNvPq");
        }
    }
}
