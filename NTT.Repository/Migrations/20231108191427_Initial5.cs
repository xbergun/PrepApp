using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NTT.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "TcNo", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5630), "johndoe@gmail.com", "John", "Doe", "12345678901", null, "johndoe" },
                    { 2, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5680), "georgebush@gmail.com", "George", "Bush", "55345678901", null, "georgebush" },
                    { 3, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5680), "michealjack@gmail.com", "Michael", "Jackson", "12345678901", null, "michaeljackson" }
                });

            migrationBuilder.InsertData(
                table: "TelephoneNumbers",
                columns: new[] { "Id", "CreatedAt", "TelNo", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5860), "05321234567", null, 1 },
                    { 2, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5860), "05321234568", null, 1 },
                    { 3, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5870), "05321234569", null, 2 },
                    { 4, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5870), "05321234570", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "RoleType", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5820), "User", null, 1 },
                    { 2, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5820), "Admin", null, 1 },
                    { 3, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5820), "Admin", null, 2 },
                    { 4, new DateTime(2023, 11, 8, 22, 14, 27, 217, DateTimeKind.Local).AddTicks(5820), "Guest", null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumbers_UserId",
                table: "TelephoneNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelephoneNumbers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
