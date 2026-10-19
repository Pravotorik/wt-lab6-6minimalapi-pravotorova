using wt_lab6_6minimalapi_pravotorova.Models;

namespace wt_lab6_6minimalapi_pravotorova.Data;

public static class GuestStore
{
    public static List<Guest> Guests { get; } = new()
    {
        new Guest { Id = 1, FullName = "Анна Смирнова", Email = "anna@mail.com", Phone = "+375 29 111-22-33" },
        new Guest { Id = 2, FullName = "Иван Петров", Email = "ivan@mail.com", Phone = "+375 29 444-55-66" },
        new Guest { Id = 3, FullName = "Мария Ковалёва", Email = "maria@mail.com", Phone = "+375 29 777-88-99" }
    };
}