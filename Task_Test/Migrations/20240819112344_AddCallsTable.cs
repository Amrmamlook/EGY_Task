using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Test.Migrations
{
    /// <inheritdoc />
    public partial class AddCallsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhone_Clients_ClientId",
                table: "UserPhone");

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    nvarchar150 = table.Column<string>(name: "nvarchar(150)", type: "nvarchar(max)", nullable: false),
                    nvarchar100 = table.Column<string>(name: "nvarchar(100)", type: "nvarchar(max)", nullable: false),
                    nvarchar200 = table.Column<string>(name: "nvarchar(200)", type: "nvarchar(max)", nullable: false),
                    CallHistory = table.Column<DateOnly>(type: "date", nullable: true),
                    nvarchar50 = table.Column<string>(name: "nvarchar(50)", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9f9ec9ad-d424-439a-944e-00a909bab626");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "36f927c8-c4fc-4f03-8521-d8e607751e6f");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b9ae9b6d-9d75-421f-a385-392361895fd6");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ClientId",
                table: "Calls",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhone_Clients_ClientId",
                table: "UserPhone",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhone_Clients_ClientId",
                table: "UserPhone");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ee82cc45-40cc-4fe6-9ef8-303918493a43");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "74596a36-bfd2-4ef8-9f7b-65233b1509da");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "593c4150-37db-4fa5-b357-0f22fa74fb1c");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhone_Clients_ClientId",
                table: "UserPhone",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
