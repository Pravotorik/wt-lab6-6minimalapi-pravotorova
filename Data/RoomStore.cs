using wt_lab6_6minimalapi_pravotorova.Models;

namespace wt_lab6_6minimalapi_pravotorova.Data;

public static class RoomStore
{
    public static List<Room> Rooms { get; } = new()
    {
        new Room { Id = 1, Number = "101", Category = "Стандарт", Capacity = 2, PricePerNight = 3500, IsAvailable = true },
        new Room { Id = 2, Number = "102", Category = "Стандарт", Capacity = 2, PricePerNight = 3700, IsAvailable = true },
        new Room { Id = 3, Number = "201", Category = "Комфорт", Capacity = 2, PricePerNight = 5200, IsAvailable = true },
        new Room { Id = 4, Number = "202", Category = "Комфорт", Capacity = 3, PricePerNight = 6100, IsAvailable = false },
        new Room { Id = 5, Number = "301", Category = "Люкс", Capacity = 3, PricePerNight = 8900, IsAvailable = true },
        new Room { Id = 6, Number = "401", Category = "Апартаменты", Capacity = 4, PricePerNight = 15000, IsAvailable = false }
    };
}