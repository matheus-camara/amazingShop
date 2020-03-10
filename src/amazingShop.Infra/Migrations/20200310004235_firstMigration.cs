using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amazingShop.Infra.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 18L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 17L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 16L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 15L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 14L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 13L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 12L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 11L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 10L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 9L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 8L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 7L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 6L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 5L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 4L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 3L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 2L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 19L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 },
                    { 20L, "camiseta", "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg", "camiseta", 18.280000000000001 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
