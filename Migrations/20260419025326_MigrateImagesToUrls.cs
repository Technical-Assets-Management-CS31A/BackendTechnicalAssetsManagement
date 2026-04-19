using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class MigrateImagesToUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackStudentIdPicture",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPicture",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPicture",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "GuestImage",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPicture",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "GuestImage",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ArchiveItems");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "Items",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "ArchiveItems",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "BackStudentIdPictureUrl",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontStudentIdPictureUrl",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontStudentIdPictureUrl",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestImageUrl",
                table: "LentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontStudentIdPictureUrl",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestImageUrl",
                table: "ArchiveLentItems",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArchiveLentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000007"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000001"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000002"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000003"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000004"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000005"),
                columns: new[] { "FrontStudentIdPictureUrl", "GuestImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                columns: new[] { "BackStudentIdPictureUrl", "FrontStudentIdPictureUrl", "ProfilePictureUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$wXCElebYXDiTi/vZYvYqFugKygT6ypSHisg1b8J05XxXOvetktQ4C");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackStudentIdPictureUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPictureUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPictureUrl",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "GuestImageUrl",
                table: "LentItems");

            migrationBuilder.DropColumn(
                name: "FrontStudentIdPictureUrl",
                table: "ArchiveLentItems");

            migrationBuilder.DropColumn(
                name: "GuestImageUrl",
                table: "ArchiveLentItems");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Items",
                newName: "ImageMimeType");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ArchiveItems",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<byte[]>(
                name: "BackStudentIdPicture",
                table: "Students",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FrontStudentIdPicture",
                table: "Students",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Students",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FrontStudentIdPicture",
                table: "LentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GuestImage",
                table: "LentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Items",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FrontStudentIdPicture",
                table: "ArchiveLentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GuestImage",
                table: "ArchiveLentItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ArchiveItems",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArchiveItems",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000005"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArchiveItems",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000006"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArchiveLentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000007"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

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
                keyValue: new Guid("00000005-0000-0000-0000-000000000001"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000002"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000003"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000004"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000005"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000006"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000007"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000008"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000001"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000002"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000003"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000004"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LentItems",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000005"),
                columns: new[] { "FrontStudentIdPicture", "GuestImage" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                columns: new[] { "BackStudentIdPicture", "FrontStudentIdPicture", "ProfilePicture" },
                values: new object[] { null, null, null });

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
    }
}
