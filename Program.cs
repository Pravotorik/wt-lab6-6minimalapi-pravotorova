using wt_lab6_6minimalapi_pravotorova.Data;
using wt_lab6_6minimalapi_pravotorova.Models;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем OpenAPI 6 блок
// builder.Services.AddOpenApi();

// 6.3 Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// OpenAPI доступен только в режиме разработки
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

// 6.3 Swagger UI
app.UseSwagger();
app.UseSwaggerUI();


// Базовый endpoint — проверка, что API работает
app.MapGet("/", () => "Minimal API работает!");

// Информация о приложении
app.MapGet("/api/info", () =>
{
    return new
    {
        Application = "Web Technologies",
        Technology = "ASP.NET Core Minimal API",
        Version = "1.0",
        Domain = "Hotel"
    };
});


var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";

// GET /api/rooms
//app.MapGet("/api/rooms", () =>
//{
//    return Results.Ok(RoomStore.Rooms);
//});

// GET /api/rooms/{id}
app.MapGet("/api/rooms/{id}", (int id) =>
{
    var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
    if (room == null)
        return Results.NotFound();
    return Results.Ok(room);
});


//GET /api/rooms?search= фильр
app.MapGet("/api/rooms", (string? search) =>
{
    var rooms = RoomStore.Rooms.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        rooms = rooms.Where(r =>
            r.Number.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            r.Category.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(rooms);
});


// POST /api/rooms
app.MapPost("/api/rooms", (Room room) =>
{
    // Автоматическая генерация Id
    room.Id = RoomStore.Rooms.Count == 0
        ? 1
        : RoomStore.Rooms.Max(r => r.Id) + 1;

    RoomStore.Rooms.Add(room);

    return Results.Created($"/api/rooms/{room.Id}", room);
});

// PUT /api/rooms/{id} — обновить
app.MapPut("/api/rooms/{id}", (int id, Room updatedRoom) =>
{
    var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
    if (room == null)
        return Results.NotFound();

    room.Number = updatedRoom.Number;
    room.Category = updatedRoom.Category;
    room.Capacity = updatedRoom.Capacity;
    room.PricePerNight = updatedRoom.PricePerNight;
    room.IsAvailable = updatedRoom.IsAvailable;

    return Results.Ok(room);
});

// DELETE /api/rooms/{id}
app.MapDelete("/api/rooms/{id}", (int id) =>
{
    var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
    if (room == null)
        return Results.NotFound();

    RoomStore.Rooms.Remove(room);
    return Results.NoContent();
});



app.Run($"http://0.0.0.0:{port}");
