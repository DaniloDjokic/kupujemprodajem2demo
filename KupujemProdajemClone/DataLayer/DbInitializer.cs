using System.Security.Cryptography;
using System.Text;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Utils;

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
            new()
            {
                Email = "test1@gmail.com",
                FirstName = "John1",
                LastName = "Doe1",
                Username = "john1",
                PasswordHash = Crypto.CalculateSha256Hash("password1"),
            },
            new()
            {
                Email = "test2@gmail.com",
                FirstName = "John2",
                LastName = "Doe2",
                Username = "john2",
                PasswordHash = Crypto.CalculateSha256Hash("password2"),
            },
            new()
            {
                Email = "test3@gmail.com",
                FirstName = "John3",
                LastName = "Doe3",
                Username = "john3",
                PasswordHash = Crypto.CalculateSha256Hash("password3"),
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var products = new Product[]
        {
            new()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new()
            {
                Name = "Test Name3",
                Description = "Test Description3",
                Price = 110.83m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new()
            {
                Name = "Test Name4",
                Description = "Test Description4",
                Price = 10001.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new()
            {
                Name = "Test Name5",
                Description = "Test Description5",
                Price = 3420.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id
            },
            new()
            {
                Name = "Test Name6",
                Description = "Test Description6",
                Price = 11000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new()
            {
                Name = "Test Name7",
                Description = "Test Description7",
                Price = 1000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new()
            {
                Name = "Test Name8",
                Description = "Test Description8",
                Price = 11000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new()
            {
                Name = "Test Name9",
                Description = "Test Description9",
                Price = 110.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
            new()
            {
                Name = "Test Name10",
                Description = "Test Description10",
                Price = 1000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[0].Id,
            },
            new()
            {
                Name = "Test Name11",
                Description = "Test Description11",
                Price = 11000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[1].Id,
            },
            new()
            {
                Name = "Test Name12",
                Description = "Test Description12",
                Price = 11000.10m,
                ImageSrc = "/imgs/stock.jpg",
                UserId = users[2].Id,
            },
        };

        context.Products.AddRange(products);
        context.SaveChanges();

        var ratings = new Rating[]
        {
            new()
            {
                RatingValue = 5,
                ProductId = products[0].Id,
                UserId = users[0].Id
            },
            new()
            {
                RatingValue = 4,
                ProductId = products[0].Id,
                UserId = users[1].Id
            },
            new()
            {
                RatingValue = 1,
                ProductId = products[1].Id,
                UserId = users[0].Id
            },
            new()
            {
                RatingValue = 2,
                ProductId = products[2].Id,
                UserId = users[1].Id
            },
            new()
            {
                RatingValue = 3,
                ProductId = products[2].Id,
                UserId = users[2].Id
            }
        };

        context.Ratings.AddRange(ratings);
        context.SaveChanges();
    }
}