using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    /// <summary>
    /// Контроллер для Администратора (список всех номеров, записи бронирования и выселения, добавление номера, удаление номера)
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private IAdminService _admin;

        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }

        /// <summary>
        /// Вывод списка всех номеров
        /// </summary>
        /// <returns>Список номеров</returns>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _admin.GetAllRooms();
        }

        /// <summary>
        /// Вывод записей бронирования и выселения
        /// </summary>
        /// <returns>Список записей</returns>
        [HttpGet("Journal")]
        public IEnumerable<BookingHistory> GetJournal()
        {
            return _admin.GetJournal();
        }

        /// <summary>
        /// Добавление нового номера
        /// </summary>
        /// <param name="newRoom">Данные номера (Number, Cost, Class, Details, BookingStatus)</param>
        /// <returns></returns>
        [HttpPost]
        public string Post(Room newRoom)
        {
            return _admin.AddRoom(newRoom);
        }

        /// <summary>
        /// Удаление номера
        /// </summary>
        /// <param name="roomNumber">Данные номера (Number, Cost, Class, Details, BookingStatus)</param>
        /// <returns></returns>
        [HttpDelete("{roomNumber}")]
        public string Delete(int roomNumber)
        {
            return _admin.DeleteRoom(roomNumber);
        }
    }
}