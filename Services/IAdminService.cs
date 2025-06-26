using HotelApi.Models;

namespace HotelApi.Services
{
    public interface IAdminService
    {
        public IEnumerable<Room> GetAllRooms(); // Вывод всех комнат
        public IEnumerable<BookingHistory> GetJournal(); // Вывод журнала засилений
        public string AddRoom(Room newRoom); // Добавление комнаты
        public string DeleteRoom(int roomNumber); // Удаление комнаты
    }
}
