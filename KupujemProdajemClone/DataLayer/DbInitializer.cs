using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;

namespace KupujemProdajemClone.DataLayer;

public class DbInitializer
{
    public static void InitDb(KupujemProdajemCloneContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        var users = new User[]
        {
            new User()
            {
                Email = "test1@gmail.com",
                FirstName = "John1",
                LastName = "Doe1",
                Username = "john1"
            },
            new User()
            {
                Email = "test2@gmail.com",
                FirstName = "John2",
                LastName = "Doe2",
                Username = "john2"
            },
            new User()
            {
                Email = "test3@gmail.com",
                FirstName = "John2",
                LastName = "Doe3",
                Username = "john3"
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var products = new Product[]
        {
            new Product()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new Product()
            {
                Name = "Test Name3",
                Description = "Test Description3",
                Price = 110.83m,
                Rating = 1,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new Product()
            {
                Name = "Test Name4",
                Description = "Test Description4",
                Price = 10001.10m,
                Rating = 2,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new Product()
            {
                Name = "Test Name5",
                Description = "Test Description5",
                Price = 3420.10m,
                Rating = 4,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id
            },
            new Product()
            {
                Name = "Test Name6",
                Description = "Test Description6",
                Price = 11000.10m,
                Rating = 2,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new Product()
            {
                Name = "Test Name7",
                Description = "Test Description7",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new Product()
            {
                Name = "Test Name8",
                Description = "Test Description8",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new Product()
            {
                Name = "Test Name9",
                Description = "Test Description9",
                Price = 110.10m,
                Rating = 4,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new Product()
            {
                Name = "Test Name10",
                Description = "Test Description10",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new Product()
            {
                Name = "Test Name11",
                Description = "Test Description11",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new Product()
            {
                Name = "Test Name12",
                Description = "Test Description12",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}