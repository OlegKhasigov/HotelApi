namespace HotelApi.Models
{
    public class BookingHistory
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string? Guest { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? EvictionDate { get; set; }
    }
}
