using WordSearch.Core.Logic;
using WordSearch.Core.Logic.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreateCustomPuzzle, CreatePuzzle>();
builder.Services.AddScoped<CreateGrid>();
builder.Services.AddScoped<SetLocations>();
builder.Services.AddSingleton<Random>();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
