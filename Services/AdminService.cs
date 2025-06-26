using HotelApi.Models;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HotelApi.Services
{
    public class AdminService : IAdminService
    {
        private AppDbContext _db; // Доступ к бд
        public AdminService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _db.Rooms.ToList();
        }

        public IEnumerable<BookingHistory> GetJournal()
        {
            return _db.BookingRecords.ToList();
        }
        public string AddRoom(Room newRoom)
        {
            if (_db.Rooms.FirstOrDefault(r => r.Number == newRoom.Number) == null)
            {
                _db.Rooms.Add(newRoom);
                _db.SaveChanges();

                if (_db.Rooms.Contains(newRoom))
                    return $"Комната {newRoom.Number} успешно добавлена!";
                else
                    return $"Комната {newRoom} не добавлена!";
            }
            else
                return $"Комната {newRoom.Number} уже существует.";
        }

        public string DeleteRoom(int roomNumber)
        {
            Room? room = _db.Rooms.FirstOrDefault(r => r.Number == roomNumber);

            if(room != null)
            {
                _db.Rooms.Remove(room);
                _db.SaveChanges();

                return $"Комната {roomNumber} успешно удалена!";
            }
            else
                return $"Комнаты с номером {roomNumber} не существует!";
        }
    }
}
