using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Migrations
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Memory_MemoryId",
                table: "Wallet");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_MemoryId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "MemoryId",
                table: "Wallet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemoryId",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    MemoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.MemoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_MemoryId",
                table: "Wallet",
                column: "MemoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Memory_MemoryId",
                table: "Wallet",
                column: "MemoryId",
                principalTable: "Memory",
                principalColumn: "MemoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
