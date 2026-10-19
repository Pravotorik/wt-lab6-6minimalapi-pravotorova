namespace wt_lab6_6minimalapi_pravotorova.Models;

public class Room
{
    public int Id { get; set; }
    public string Number { get; set; } = "";
    public string Category { get; set; } = "";
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}