using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTechnicalAssetsManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    ActorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActorName = table.Column<string>(type: "text", nullable: false),
                    ActorRole = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    ItemSerialNumber = table.Column<string>(type: "text", nullable: true),
                    LentItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    PreviousStatus = table.Column<string>(type: "text", nullable: true),
                    NewStatus = table.Column<string>(type: "text", nullable: true),
                    BorrowedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReservedFor = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_LentItems_LentItemId",
                        column: x => x.LentItemId,
                        principalTable: "LentItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Users_ActorUserId",
                        column: x => x.ActorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$4pmGV1R1QsyA2e2114tjlOrMhYIE3B/RfBdlRMO6SN2D.1Ur4sPjq");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ActorUserId",
                table: "ActivityLogs",
                column: "ActorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ItemId",
                table: "ActivityLogs",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_LentItemId",
                table: "ActivityLogs",
                column: "LentItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "ArchiveUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000005"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000006"),
                column: "PasswordHash",
                value: "$2a$11$KvazBSuoG6q/bp/Ii4OABeCj5XwxRDx3pm8rD2HS7UAbp3lqAmneK");
        }
    }
}
