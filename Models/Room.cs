namespace HotelApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Cost { get; set; }
        public string? Class { get; set; }
        public string? Details { get; set; }
        public bool BookingStatus { get; set; } = false;
    }
}
