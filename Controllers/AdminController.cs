using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    /// <summary>
    /// ���������� ��� �������������� (������ ���� �������, ������ ������������ � ���������, ���������� ������, �������� ������)
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
        /// ����� ������ ���� �������
        /// </summary>
        /// <returns>������ �������</returns>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _admin.GetAllRooms();
        }

        /// <summary>
        /// ����� ������� ������������ � ���������
        /// </summary>
        /// <returns>������ �������</returns>
        [HttpGet("Journal")]
        public IEnumerable<BookingHistory> GetJournal()
        {
            return _admin.GetJournal();
        }

        /// <summary>
        /// ���������� ������ ������
        /// </summary>
        /// <param name="newRoom">������ ������ (Number, Cost, Class, Details, BookingStatus)</param>
        /// <returns></returns>
        [HttpPost]
        public string Post(Room newRoom)
        {
            return _admin.AddRoom(newRoom);
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        /// <param name="roomNumber">������ ������ (Number, Cost, Class, Details, BookingStatus)</param>
        /// <returns></returns>
        [HttpDelete("{roomNumber}")]
        public string Delete(int roomNumber)
        {
            return _admin.DeleteRoom(roomNumber);
        }
    }
}