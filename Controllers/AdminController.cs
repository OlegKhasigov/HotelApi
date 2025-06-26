using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private IAdminService _admin;

        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _admin.GetAllRooms();
        }

        [HttpGet("Journal")]
        public IEnumerable<BookingHistory> GetJournal()
        {
            return _admin.GetJournal();
        }

        [HttpPost]
        public string Post(Room newRoom)
        {
            return _admin.AddRoom(newRoom);
        }

        [HttpDelete("{roomNumber}")]
        public string Delete(int roomNumber)
        {
            return _admin.DeleteRoom(roomNumber);
        }
    }
}