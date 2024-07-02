var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapControllers();

#region Minimal API's Example
//Routing
//"/shirts"
//app.MapGet("/shirts", () =>
//{
//    return "Ready all the shirts.";
//});

////"/shirts/id"
//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"Reading shirt with ID : {id}";
//});

//app.MapPost("/shirts", () =>
//{
//    return "Creating a shirt.";
//});

//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updating shirt with ID : {id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleting shirt with ID : {id}";
//});
#endregion

app.Run();
