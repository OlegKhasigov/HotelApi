using HotelApi.Models;

namespace HotelApi.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Room> GetAvailabelRooms()
        {
            List<Room> rooms = _db.Rooms.Where(r => r.BookingStatus == false).ToList();
            return rooms;
        }

        public string BookARoom(int roomNumber, string guestName)
        {
            Room? room = _db.Rooms.FirstOrDefault(r => r.Number == roomNumber);

            if (room != null)
            {
                if (room.BookingStatus)
                    return $"Комната {roomNumber} не доступна!";
                else
                {
                    BookingHistory record = new BookingHistory()
                    {
                        RoomNumber = roomNumber,
                        Guest = guestName,
                        BookingDate = DateTime.UtcNow,
                        EvictionDate = null
                    };

                    room.BookingStatus = true;

                    _db.Rooms.Update(room);
                    _db.BookingRecords.Add(record);

                    _db.SaveChanges();

                    return $"Комната {roomNumber} успешно забронирована!";
                }
            }
            else
                return $"Комнаты {roomNumber} не существует!";
        }

        public string MoveOut(int roomNumber, string guestName)
        {
            Room? room = _db.Rooms.FirstOrDefault(r => r.Number == roomNumber);
            BookingHistory? record = _db.BookingRecords.FirstOrDefault(b => b.Guest == guestName);

            if(room != null)
            {
                if(record != null)
                {
                    if (room.BookingStatus)
                    {
                        room.BookingStatus = false;
                        record.EvictionDate = DateTime.UtcNow;

                        _db.Rooms.Update(room);
                        _db.BookingRecords.Update(record);

                        _db.SaveChanges();

                        return $"Приходите еще!";
                    }
                    else
                        return $"Комната {roomNumber} не была забронирована!";
                }
                else
                    return $"У нас нет гостей с именем {guestName}!";
            }
            else
                return $"Комнаты {roomNumber} не существует!";
        }

    }
}
