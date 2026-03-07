using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagmentDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembePlan_Members_MemberId",
                table: "MembePlan");

            migrationBuilder.DropForeignKey(
                name: "FK_MembePlan_Plans_PlanId",
                table: "MembePlan");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberBookSession_Members_MemberId",
                table: "MemberBookSession");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberBookSession_Sessions_SessionId",
                table: "MemberBookSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Category_CategoryId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberBookSession",
                table: "MemberBookSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembePlan",
                table: "MembePlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "MemberBookSession",
                newName: "memberBookSessions");

            migrationBuilder.RenameTable(
                name: "MembePlan",
                newName: "membePlans");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "categories");

            migrationBuilder.RenameIndex(
                name: "IX_MemberBookSession_SessionId",
                table: "memberBookSessions",
                newName: "IX_memberBookSessions_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_MembePlan_PlanId",
                table: "membePlans",
                newName: "IX_membePlans_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memberBookSessions",
                table: "memberBookSessions",
                columns: new[] { "MemberId", "SessionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_membePlans",
                table: "membePlans",
                columns: new[] { "MemberId", "PlanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_membePlans_Members_MemberId",
                table: "membePlans",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_membePlans_Plans_PlanId",
                table: "membePlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberBookSessions_Members_MemberId",
                table: "memberBookSessions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberBookSessions_Sessions_SessionId",
                table: "memberBookSessions",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_categories_CategoryId",
                table: "Sessions",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_membePlans_Members_MemberId",
                table: "membePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_membePlans_Plans_PlanId",
                table: "membePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_memberBookSessions_Members_MemberId",
                table: "memberBookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_memberBookSessions_Sessions_SessionId",
                table: "memberBookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_categories_CategoryId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memberBookSessions",
                table: "memberBookSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_membePlans",
                table: "membePlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "memberBookSessions",
                newName: "MemberBookSession");

            migrationBuilder.RenameTable(
                name: "membePlans",
                newName: "MembePlan");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_memberBookSessions_SessionId",
                table: "MemberBookSession",
                newName: "IX_MemberBookSession_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_membePlans_PlanId",
                table: "MembePlan",
                newName: "IX_MembePlan_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberBookSession",
                table: "MemberBookSession",
                columns: new[] { "MemberId", "SessionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembePlan",
                table: "MembePlan",
                columns: new[] { "MemberId", "PlanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembePlan_Members_MemberId",
                table: "MembePlan",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembePlan_Plans_PlanId",
                table: "MembePlan",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberBookSession_Members_MemberId",
                table: "MemberBookSession",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberBookSession_Sessions_SessionId",
                table: "MemberBookSession",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Category_CategoryId",
                table: "Sessions",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
