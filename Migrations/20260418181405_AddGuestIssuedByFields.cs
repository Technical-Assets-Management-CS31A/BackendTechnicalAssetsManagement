using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddGuestIssuedByFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GuestImage",
                table: "LentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IssuedById",
                table: "LentItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuedByLastName",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GuestImage",
                table: "ArchiveLentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArchiveLentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000007"),
                columns: new[] { "ContactNumber", "GuestImage", "Organization", "Purpose" },
                values: new object[] { null, null, null, null });

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
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000001"),
                columns: new[] { "ContactNumber", "GuestImage", "IssuedById", "IssuedByLastName", "Organization", "Purpose" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000002"),
                columns: new[] { "ContactNumber", "GuestImage", "IssuedById", "IssuedByLastName", "Organization", "Purpose" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000003"),
                columns: new[] { "ContactNumber", "GuestImage", "IssuedById", "IssuedByLastName", "Organization", "Purpose" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000004"),
                columns: new[] { "ContactNumber", "GuestImage", "IssuedById", "IssuedByLastName", "Organization", "Purpose" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000005"),
                columns: new[] { "ContactNumber", "GuestImage", "IssuedById", "IssuedByLastName", "Organization", "Purpose" },
                values: new object[] { null, null, null, null, null, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "GuestImage",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "IssuedById",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "IssuedByLastName",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "GuestImage",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "ArchiveLentItems");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$TAbD0Uied95H9OYNZdgx7uPA4PN6.PBM9CIAwB3k5cbcgMlEUskA.");
        }
    }
}
