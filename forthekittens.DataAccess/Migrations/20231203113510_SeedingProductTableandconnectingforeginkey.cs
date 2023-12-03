using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace forthekittens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProductTableandconnectingforeginkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ListPrice", "Manufacturer", "Price", "Price10", "Price5", "Product_description", "Product_name", "Upc" },
                values: new object[,]
                {
                    { 1, 1, 400, "JoyfulPets Creations", 350, 3000, 1500, "A vibrant, rainbow-colored ball toy with attached feathers, designed to engage your cat in playful activities.", "Rainbow Whisker Ball Toy", "111222333444" },
                    { 2, 1, 799, "Paws & Whiskers Co.", 600, 5000, 2500, "A multi-level cat tree condo with scratching posts, cozy hideaways, and dangling toys.", "Cat Haven Deluxe Tree", "123456789012" },
                    { 3, 1, 899, "DreamyPets Couture", 700, 6000, 3000, "A hammock-style bed for cats with a fluffy pillow, creating a cozy spot for your cat to nap in style.", "Sweet Dreams Cat Hammock", "222333444555" },
                    { 4, 2, 1999, "Meow Mix Delights", 1500, 10000, 5000, "A high-quality, grain-free cat food with a blend of premium ingredients for a happy and healthy cat.", "Gourmet Purrfection Cat Cuisine", "234567890123" },
                    { 5, 2, 449, "SnugglePaws Co.", 400, 3600, 1800, "A super-soft plush blanket with a cute paw print design, providing warmth and comfort for your cat.", "WhiskerWonder Plush Blanket", "333444555666" },
                    { 6, 3, 499, "Whisker Wonders Ltd.", 450, 3600, 2000, "A set of interactive toys, including feather wands, laser pointers, and treat-dispensing balls, to keep your cat entertained for hours.", "Playful Paws Interactive Toy Set", "345678901234" },
                    { 7, 3, 299, "ChicKitty Accessories", 250, 1800, 1000, "A set of adorable ceramic cat bowls with cute cat illustrations, perfect for serving your cat's meals in style.", "Cute Kitty Ceramic Bowl Set", "444555666777" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
