using Microsoft.EntityFrameworkCore.Migrations;

namespace GPIHTask.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOnMarketPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MarketId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOnMarketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOnMarketPrices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOnMarketPrices_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "FullName", "PasswordHash", "UserName" },
                values: new object[] { "087855c6-db47-4a9b-bb7e-b5d4b21f1cef", "Vakhtang Peradze", "AQAAAAEAACcQAAAAEInV6NCo7Mb+HJEQqfU39gNcodsOKLYU0S7N48CdGRkx1YDIH+LbhjlJ1h5hQzzNPQ==", "admin" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "LogoPath", "Title" },
                values: new object[,]
                {
                    { 1, "", "../assets/images/apple.png", "Apple" },
                    { 2, "", "../assets/images/Microsoft.png", "Microsoft" },
                    { 3, "", "../assets/images/Google.png", "Google" },
                    { 4, "", "../assets/images/GPIH.png", "GPIH" },
                    { 5, "", "../assets/images/Ford.png", "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "", "Market 1" },
                    { 2, "", "Market 2" },
                    { 3, "", "Market 3" }
                });

            migrationBuilder.InsertData(
                table: "CompanyOnMarketPrices",
                columns: new[] { "Id", "CompanyId", "MarketId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 0.0m },
                    { 2, 2, 1, 0.0m },
                    { 3, 3, 1, 0.0m },
                    { 4, 4, 1, 0.0m },
                    { 5, 5, 1, 0.0m },
                    { 6, 1, 2, 0.0m },
                    { 7, 2, 2, 0.0m },
                    { 8, 3, 2, 0.0m },
                    { 9, 4, 2, 0.0m },
                    { 10, 5, 2, 0.0m },
                    { 11, 1, 3, 0.0m },
                    { 12, 2, 3, 0.0m },
                    { 13, 3, 3, 0.0m },
                    { 14, 4, 3, 0.0m },
                    { 15, 5, 3, 0.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOnMarketPrices_CompanyId",
                table: "CompanyOnMarketPrices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOnMarketPrices_MarketId",
                table: "CompanyOnMarketPrices",
                column: "MarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CompanyOnMarketPrices");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Markets");
        }
    }
}
