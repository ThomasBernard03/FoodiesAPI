using AutoMapper;
using Foodies.DataAccess;
using Foodies.Mapping;
using Foodies.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile<IngredientProfile>();
    config.AddProfile<RecipeProfile>();
    config.AddProfile<StepProfile>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddScoped(_ => new FoodiesDbContext(dbConnection));

var app = builder.Build();

app.UseMiddleware<AuthenticationMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //FakeDataSeeder.Seed(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();