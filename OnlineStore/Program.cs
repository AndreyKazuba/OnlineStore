using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineStore.Data;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Constants.Enums;
using OnlineStore.Models;

#nullable disable
namespace OnlineStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<OnlineStoreDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddAuthorization();
            ConfigureJwt(builder);

            WebApplication app = builder.Build();

            ConfigureDefaultUrl(app);
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            ConfigureWebApi(app);

            app.Run();
        }

        private static void ConfigureJwt(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = AuthOptions.Issuer,
                       ValidateAudience = true,
                       ValidAudience = AuthOptions.Audience,
                       ValidateLifetime = true,
                       IssuerSigningKey = AuthOptions.SymmetricSecurityKey,
                       ValidateIssuerSigningKey = true,
                   };
               });
        }

        private static void ConfigureDefaultUrl(WebApplication app)
        {
            app.Use(async (httpContext, next) =>
            {
                string path = httpContext.Request.Path.Value;
                if (path == "/")
                {
                    httpContext.Response.Redirect("/main/index.html");
                    return;
                }

                await next.Invoke();
            });
        }

        private static void ConfigureWebApi(WebApplication app)
        {
            app.MapPost("api/login", async ([FromBody] LoginDto loginDto, OnlineStoreDbContext dbContext) =>
            {
                if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Password) || string.IsNullOrWhiteSpace(loginDto.Email))
                    return Results.BadRequest();


                User user = await dbContext.Users.FirstOrDefaultAsync(currentUser => currentUser.Email == loginDto.Email);
                if (user == null)
                    return Results.Conflict();

                if (user.IsBlocked)
                    return Results.Forbid();

                string outerPasswordHash = PasswordHasher.GetHashString(loginDto.Password);
                if (user.Password != outerPasswordHash)
                    return Results.Unauthorized();

                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), };
                JwtSecurityToken jwt = new JwtSecurityToken(
                        issuer: AuthOptions.Issuer,
                        audience: AuthOptions.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1000)),
                        signingCredentials: new SigningCredentials(AuthOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256));

                string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return Results.Ok(new
                {
                    Jwt = encodedJwt,
                    IsAdmin = user.IsAdmin,
                });
            });

            app.MapPost("api/register", async ([FromBody] RegisterDto registerDto, OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                if (registerDto == null
                    || string.IsNullOrWhiteSpace(registerDto.Email)
                    || string.IsNullOrWhiteSpace(registerDto.Password)
                    || string.IsNullOrWhiteSpace(registerDto.PasswordConfirmation))
                    return Results.BadRequest();

                if (registerDto.Password != registerDto.PasswordConfirmation)
                    return Results.Unauthorized();

                bool userExist = await dbContext.Users.AnyAsync(user => user.Email == registerDto.Email);
                if (userExist)
                    return Results.Conflict();

                User newUser = dbContext.Users.Add(new User
                {
                    Email = registerDto.Email,
                    IsAdmin = false,
                    Password = PasswordHasher.GetHashString(registerDto.Password)
                }).Entity;

                await dbContext.SaveChangesAsync();

                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()), };
                JwtSecurityToken jwt = new JwtSecurityToken(
                        issuer: AuthOptions.Issuer,
                        audience: AuthOptions.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1000)),
                        signingCredentials: new SigningCredentials(AuthOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256));

                string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return Results.Ok(encodedJwt);
            });

            app.MapGet("api/bestsellers", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var bestsellers = from product in dbContext.Products
                                      join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                      on product.Id equals cartItem.ProductId into cartItems
                                      from cartItem in cartItems.DefaultIfEmpty()
                                      where product.IsBestseller
                                      select new
                                      {
                                          product.Name,
                                          product.Description,
                                          product.Price,
                                          product.ImageName,
                                          product.Type,
                                          InCart = cartItem != null,
                                          product.Id,
                                      };

                    return Results.Ok(bestsellers);
                }
                else
                {
                    List<Product> bestsellers = await dbContext.Products
                        .Where(product => product.IsBestseller)
                        .ToListAsync();

                    return Results.Ok(bestsellers);
                }
            });

            app.MapGet("api/catalog", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var products = from product in dbContext.Products
                                   join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                   on product.Id equals cartItem.ProductId into cartItems
                                   from cartItem in cartItems.DefaultIfEmpty()
                                   select new
                                   {
                                       product.Name,
                                       product.Description,
                                       product.Price,
                                       product.ImageName,
                                       product.Type,
                                       InCart = cartItem != null,
                                       product.Id,
                                   };

                    return Results.Ok(products);
                }
                else
                {
                    List<Product> products = await dbContext.Products.ToListAsync();
                    return Results.Ok(products);
                }
            });

            app.MapGet("api/catalog/videocards", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var videocards = from product in dbContext.Products
                                     join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                     on product.Id equals cartItem.ProductId into cartItems
                                     from cartItem in cartItems.DefaultIfEmpty()
                                     where product.Type == ProductType.Videocard
                                     select new
                                     {
                                         product.Name,
                                         product.Description,
                                         product.Price,
                                         product.ImageName,
                                         product.Type,
                                         InCart = cartItem != null,
                                         product.Id,
                                     };

                    return Results.Ok(videocards);
                }
                else
                {
                    List<Product> videocards = await dbContext.Products
                        .Where(product => product.Type == ProductType.Videocard)
                        .ToListAsync();

                    return Results.Ok(videocards);
                }
            });

            app.MapGet("api/catalog/processors", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var processors = from product in dbContext.Products
                                     join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                     on product.Id equals cartItem.ProductId into cartItems
                                     from cartItem in cartItems.DefaultIfEmpty()
                                     where product.Type == ProductType.Processor
                                     select new
                                     {
                                         product.Name,
                                         product.Description,
                                         product.Price,
                                         product.ImageName,
                                         product.Type,
                                         InCart = cartItem != null,
                                         product.Id,
                                     };

                    return Results.Ok(processors);
                }
                else
                {
                    List<Product> processors = await dbContext.Products
                        .Where(product => product.Type == ProductType.Processor)
                        .ToListAsync();

                    return Results.Ok(processors);
                }
            });

            app.MapGet("api/catalog/mother-boards", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var motherBoards = from product in dbContext.Products
                                       join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                       on product.Id equals cartItem.ProductId into cartItems
                                       from cartItem in cartItems.DefaultIfEmpty()
                                       where product.Type == ProductType.MotherBoard
                                       select new
                                       {
                                           product.Name,
                                           product.Description,
                                           product.Price,
                                           product.ImageName,
                                           product.Type,
                                           InCart = cartItem != null,
                                           product.Id,
                                       };

                    return Results.Ok(motherBoards);
                }
                else
                {
                    List<Product> motherBoards = await dbContext.Products
                        .Where(product => product.Type == ProductType.MotherBoard)
                        .ToListAsync();

                    return Results.Ok(motherBoards);
                }
            });

            app.MapGet("api/catalog/ready-assemblies", async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var readyAssemblies = from product in dbContext.Products
                                          join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                          on product.Id equals cartItem.ProductId into cartItems
                                          from cartItem in cartItems.DefaultIfEmpty()
                                          where product.Type == ProductType.ReadyAssembly
                                          select new
                                          {
                                              product.Name,
                                              product.Description,
                                              product.Price,
                                              product.ImageName,
                                              product.Type,
                                              InCart = cartItem != null,
                                              product.Id,
                                          };

                    return Results.Ok(readyAssemblies);
                }
                else
                {
                    List<Product> readyAssemblies = await dbContext.Products
                        .Where(product => product.Type == ProductType.ReadyAssembly)
                        .ToListAsync();

                    return Results.Ok(readyAssemblies);
                }
            });

            app.MapPut("api/cart/items", [Authorize] async ([FromBody] int productId, OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(idClaim.Value);
                dbContext.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    OwnerId = userId,
                    Count = 1,
                });

                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPut("api/cart/items/delete", [Authorize] async ([FromBody] int productId, OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(idClaim.Value);
                CartItem cartItem = await dbContext.CartItems
                    .FirstAsync(item => item.ProductId == productId && item.OwnerId == userId);

                dbContext.CartItems.Remove(cartItem);
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPut("api/cart/items/increase-count", async ([FromBody] int cartItemId, OnlineStoreDbContext dbContext) =>
            {
                CartItem cartItem = await dbContext.CartItems.FirstAsync(item => item.Id == cartItemId);
                cartItem.Count += 1;

                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPut("api/cart/items/reduce-count", async ([FromBody] int cartItemId, OnlineStoreDbContext dbContext) =>
            {
                CartItem cartItem = await dbContext.CartItems.FirstAsync(item => item.Id == cartItemId);
                cartItem.Count -= 1;

                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapGet("api/cart/items", [Authorize] async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(idClaim.Value);
                var cartItems = await (from cartItem in dbContext.CartItems
                                       join product in dbContext.Products
                                       on cartItem.ProductId equals product.Id
                                       where cartItem.OwnerId == userId
                                       select new
                                       {
                                           product.Name,
                                           product.Description,
                                           product.Price,
                                           product.ImageName,
                                           product.Type,
                                           cartItem.Count,
                                           product.Id,
                                           CartItemId = cartItem.Id,
                                       }).ToListAsync();

                return Results.Ok(cartItems);
            });

            app.MapPost("api/buy", [Authorize] async (OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(idClaim.Value);

                List<CartItem> cartItems = await dbContext.CartItems.Where(cartItem => cartItem.OwnerId == userId).ToListAsync();
                dbContext.CartItems.RemoveRange(cartItems);
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapGet("api/search/{searchString}", async ([FromRoute] string searchString, OnlineStoreDbContext dbContext, HttpContext httpContext) =>
            {
                Claim idClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim?.Value, out Guid userId))
                {
                    var searchResult = from product in dbContext.Products
                                       join cartItem in dbContext.CartItems.Where(item => item.OwnerId == userId)
                                       on product.Id equals cartItem.ProductId into cartItems
                                       from cartItem in cartItems.DefaultIfEmpty()
                                       where product.Name.Contains(searchString) || product.Description.Contains(searchString)
                                       select new
                                       {
                                           product.Name,
                                           product.Description,
                                           product.Price,
                                           product.ImageName,
                                           product.Type,
                                           InCart = cartItem != null,
                                           product.Id,
                                       };

                    return Results.Ok(searchResult);
                }
                else
                {
                    List<Product> searchResult = await dbContext.Products
                        .Where(product => product.Name.Contains(searchString) || product.Description.Contains(searchString))
                        .ToListAsync();

                    return Results.Ok(searchResult);
                }
            });

            app.MapGet("api/users", [Authorize] async (OnlineStoreDbContext dbContext) =>
            {
                List<User> users = await dbContext.Users
                    .Where(user => !user.IsAdmin)
                    .ToListAsync();

                return Results.Ok(users);
            });

            app.MapPost("api/users/block", [Authorize] async ([FromBody] Guid userId, OnlineStoreDbContext dbContext) =>
            {
                User user = await dbContext.Users.FirstAsync(currentUser => currentUser.Id == userId);
                user.IsBlocked = true;
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPost("api/users/unblock", [Authorize] async ([FromBody] Guid userId, OnlineStoreDbContext dbContext) =>
            {
                User user = await dbContext.Users.FirstAsync(currentUser => currentUser.Id == userId);
                user.IsBlocked = false;
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapGet("api/products", [Authorize] async (OnlineStoreDbContext dbContext) =>
            {
                List<Product> products = await dbContext.Products.ToListAsync();
                return Results.Ok(products);
            });

            app.MapPost("api/products", [Authorize] async ([FromBody] NewProductDto newProductDto, OnlineStoreDbContext dbContext) =>
            {
                if (newProductDto == null
                    || string.IsNullOrWhiteSpace(newProductDto.Name)
                    || string.IsNullOrWhiteSpace(newProductDto.Description)
                    || newProductDto.Price <= 0
                    || newProductDto.Type == 0)
                    return Results.BadRequest();

                dbContext.Products.Add(new Product
                {
                    Name = newProductDto.Name,
                    Description = newProductDto.Description,
                    IsBestseller = false,
                    Price = newProductDto.Price,
                    Type = (ProductType)newProductDto.Type,
                    ImageName = ImageNames.DefaultName,
                });

                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPost("api/products/delete", [Authorize] async ([FromBody] int productId, OnlineStoreDbContext dbContext) =>
            {
                Product product = await dbContext.Products.FirstAsync(currentProruct => currentProruct.Id == productId);
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}