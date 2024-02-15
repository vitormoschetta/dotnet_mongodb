using dotnet_mongodb.Data;
using dotnet_mongodb.Shared;
using dotnet_mongodb.Todo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<TodoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
