var builder = WebApplication.CreateBuilder(args);

// Servisleri konteyn?ra ekleme.
builder.Services.AddControllers(); // Controller'lar? ekler, bu sayede MVC pattern’i desteklenir.

// Swagger/OpenAPI yap?land?rmas?.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Yetkilendirme ve kimlik do?rulama politikalar?n? ekleme.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Basket.Read", policy => policy.RequireClaim("Permission", "Basket.Read"));
    options.AddPolicy("Basket.Write", policy => policy.RequireClaim("Permission", "Basket.Write"));
    options.AddPolicy("Basket.Update", policy => policy.RequireClaim("Permission", "Basket.Update"));
    options.AddPolicy("Basket.Delete", policy => policy.RequireClaim("Permission", "Basket.Delete"));

    // Order için yetkilendirme politikalar?
    options.AddPolicy("Order.Read", policy => policy.RequireClaim("Permission", "Order.Read"));
    options.AddPolicy("Order.Write", policy => policy.RequireClaim("Permission", "Order.Write"));
    options.AddPolicy("Order.Update", policy => policy.RequireClaim("Permission", "Order.Update"));

    //Product için
    options.AddPolicy("Product.Read", policy => policy.RequireClaim("Permission", "Product.Read"));
    options.AddPolicy("Product.Write", policy => policy.RequireClaim("Permission", "Product.Write"));
    options.AddPolicy("Product.Update", policy => policy.RequireClaim("Permission", "Product.Update"));
    options.AddPolicy("Product.Delete", policy => policy.RequireClaim("Permission", "Product.Delete"));

    //User
    options.AddPolicy("Users.Read", policy => policy.RequireClaim("Permission", "Users.Read"));
    options.AddPolicy("Users.Write", policy => policy.RequireClaim("Permission", "Users.Write"));
    options.AddPolicy("Users.AssignRole", policy => policy.RequireClaim("Permission", "Users.AssignRole"));
});
 

var app = builder.Build();

// HTTP istek hatt?n? yap?land?rma.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Yetkilendirme ve kimlik do?rulama middleware’leri.
app.UseAuthorization();

app.MapControllers();

app.Run();
