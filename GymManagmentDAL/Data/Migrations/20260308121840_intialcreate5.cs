using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagmentDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthRecord_CreatedAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Id",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_UpdateAt",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "HealthRecord_Weight",
                table: "Members",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "HealthRecord_Note",
                table: "Members",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "HealthRecord_Height",
                table: "Members",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "HealthRecord_BloodType",
                table: "Members",
                newName: "BloodType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Members",
                newName: "HealthRecord_Weight");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Members",
                newName: "HealthRecord_Note");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Members",
                newName: "HealthRecord_Height");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "Members",
                newName: "HealthRecord_BloodType");

            migrationBuilder.AddColumn<DateTime>(
                name: "HealthRecord_CreatedAt",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HealthRecord_Id",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HealthRecord_UpdateAt",
                table: "Members",
                type: "datetime2",
                nullable: true);
        }
    }
}
