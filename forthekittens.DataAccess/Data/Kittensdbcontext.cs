    using forthekittens.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    namespace forthekittens.DataAccess.Data
    {
        public class Kittensdbcontext : DbContext
        {
            public Kittensdbcontext(DbContextOptions<Kittensdbcontext> options) : base(options)  //means we are passing the connection string to the dbcontext class through the constructor
            {

            }
            //when creating a table we need to create Dbset
            public DbSet<Category> Categories { get; set; } //category table and catagories is the table name
                                                            // "add-migration NameOfMigration " command to create table

            public DbSet<Product> Products { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Toys", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Apparels", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                    // New Product Entry
                    new Product
                    {
                        Id = 1,
                        Product_name = "Rainbow Whisker Ball Toy",
                        Product_description = "A vibrant, rainbow-colored ball toy with attached feathers, designed to engage your cat in playful activities.",
                        Upc = "111222333444",
                        Manufacturer = "JoyfulPets Creations",
                        ListPrice = 400,
                        Price = 350,
                        Price5 = 1500,
                        Price10 = 3000,
                        CategoryId = 1,
                        ImageUrl=""
                    },

                    // Cat Haven Deluxe Tree
                    new Product
                    {
                        Id = 2,
                        Product_name = "Cat Haven Deluxe Tree",
                        Product_description = "A multi-level cat tree condo with scratching posts, cozy hideaways, and dangling toys.",
                        Upc = "123456789012",
                        Manufacturer = "Paws & Whiskers Co.",
                        ListPrice = 799,
                        Price = 600,
                        Price5 = 2500,
                        Price10 = 5000,
                        CategoryId = 1,
                        ImageUrl = ""
                    },

                    // New Product Entry
                    new Product
                    {
                        Id = 3,
                        Product_name = "Sweet Dreams Cat Hammock",
                        Product_description = "A hammock-style bed for cats with a fluffy pillow, creating a cozy spot for your cat to nap in style.",
                        Upc = "222333444555",
                        Manufacturer = "DreamyPets Couture",
                        ListPrice = 899,
                        Price = 700,
                        Price5 = 3000,
                        Price10 = 6000,
                        CategoryId = 1,
                        ImageUrl = ""
                    },

                    // Gourmet Purrfection Cat Cuisine
                    new Product
                    {
                        Id = 4,
                        Product_name = "Gourmet Purrfection Cat Cuisine",
                        Product_description = "A high-quality, grain-free cat food with a blend of premium ingredients for a happy and healthy cat.",
                        Upc = "234567890123",
                        Manufacturer = "Meow Mix Delights",
                        ListPrice = 1999,
                        Price = 1500,
                        Price5 = 5000,
                        Price10 = 10000,
                        CategoryId = 2,
                        ImageUrl = ""
                    },

                    // New Product Entry
                    new Product
                    {
                        Id = 5,
                        Product_name = "WhiskerWonder Plush Blanket",
                        Product_description = "A super-soft plush blanket with a cute paw print design, providing warmth and comfort for your cat.",
                        Upc = "333444555666",
                        Manufacturer = "SnugglePaws Co.",
                        ListPrice = 449,
                        Price = 400,
                        Price5 = 1800,
                        Price10 = 3600,
                        CategoryId = 2,
                        ImageUrl = ""
                    },

                    // Playful Paws Interactive Toy Set
                    new Product
                    {
                        Id = 6,
                        Product_name = "Playful Paws Interactive Toy Set",
                        Product_description = "A set of interactive toys, including feather wands, laser pointers, and treat-dispensing balls, to keep your cat entertained for hours.",
                        Upc = "345678901234",
                        Manufacturer = "Whisker Wonders Ltd.",
                        ListPrice = 499,
                        Price = 450,
                        Price5 = 2000,
                        Price10 = 3600,
                        CategoryId = 3,
                        ImageUrl = ""
                    },

                    // New Product Entry
                    new Product
                    {
                        Id = 7,
                        Product_name = "Cute Kitty Ceramic Bowl Set",
                        Product_description = "A set of adorable ceramic cat bowls with cute cat illustrations, perfect for serving your cat's meals in style.",
                        Upc = "444555666777",
                        Manufacturer = "ChicKitty Accessories",
                        ListPrice = 299,
                        Price = 250,
                        Price5 = 1000,
                        Price10 = 1800,
                        CategoryId = 3,
                        ImageUrl = ""
                    });

        }
    }
    }
