using AutoMapper;
using Foodies.DataAccess;
using Foodies.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile<IngredientProfile>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddScoped(_ => new FoodiesDbContext(dbConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    FakeDataSeeder.Seed(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();