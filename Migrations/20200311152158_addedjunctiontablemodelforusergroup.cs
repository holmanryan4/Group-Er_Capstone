using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Migrations
{
    public partial class addedjunctiontablemodelforusergroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Activity_EventId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Group_GroupId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_GroupId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_Group_EventId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Group",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityTrnsaction",
                columns: table => new
                {
                    TransationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchases = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTrnsaction", x => x.TransationId);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserAccountId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroups_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_ActivityId",
                table: "Group",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Activity_ActivityId",
                table: "Group",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Activity_ActivityId",
                table: "Group");

            migrationBuilder.DropTable(
                name: "ActivityTrnsaction");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_Group_ActivityId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_GroupId",
                table: "UserAccount",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_EventId",
                table: "Group",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Activity_EventId",
                table: "Group",
                column: "EventId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Group_GroupId",
                table: "UserAccount",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
