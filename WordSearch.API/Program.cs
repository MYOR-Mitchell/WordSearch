using WordSearch.Core.Logic;
using WordSearch.Core.Logic.Grid;
using WordSearch.Core.Logic.Interface;
using WordSearch.Core.Logic.Locations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreatePuzzle, CreatePuzzle>();
builder.Services.AddScoped<CreateEmptyGrid>(); 
builder.Services.AddScoped<FillEmptyGrid>();
builder.Services.AddScoped<SetLocations>();
builder.Services.AddScoped<AssignStartPoint>(); 
builder.Services.AddScoped<AssignWordCoordinates>();
builder.Services.AddScoped<CheckBoundary>();
builder.Services.AddScoped<TryWordPlacement>();
builder.Services.AddScoped<Random>();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
