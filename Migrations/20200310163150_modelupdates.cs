using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Migrations
{
    public partial class modelupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Group_GroupId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "TransAmount",
                table: "Transactions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Group_GroupId",
                table: "UserAccount",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Group_GroupId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "TransAmount",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "UserAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
