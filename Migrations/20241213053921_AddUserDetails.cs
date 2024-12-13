using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashShop.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "BookId",
            //    table: "OrdersDetails",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(long),
            //    oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdersDetails_BookId",
            //    table: "OrdersDetails",
            //    column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrdersDetails_Books_BookId",
            //    table: "OrdersDetails",
            //    column: "BookId",
            //    principalTable: "Books",
            //    principalColumn: "BookId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrdersDetails_Books_BookId",
            //    table: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrdersDetails_BookId",
                table: "OrdersDetails");

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                table: "OrdersDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
