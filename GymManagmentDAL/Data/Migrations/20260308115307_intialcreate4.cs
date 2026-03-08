using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagmentDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.AddColumn<string>(
                name: "HealthRecord_BloodType",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HealthRecord_CreatedAt",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "HealthRecord_Height",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HealthRecord_Id",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HealthRecord_Note",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HealthRecord_UpdateAt",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HealthRecord_Weight",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthRecord_BloodType",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_CreatedAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Height",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Id",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Note",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_UpdateAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Weight",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
