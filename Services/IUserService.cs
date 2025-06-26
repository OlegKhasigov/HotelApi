using HotelApi.Models;

namespace HotelApi.Services
{
    public interface IUserService
    {
        public IEnumerable<Room> GetAvailabelRooms(); // Вывод всех свободных комнат
        public string BookARoom(int roomNumber, string guestName); // Бронирование конкретной комнаты
        public string MoveOut(int roomNumber, string guestName); // Выселение
    }
}
