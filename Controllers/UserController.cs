using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _user;

    public UserController(IUserService user)
    {
        _user = user;
    }

    [HttpGet]
    public IEnumerable<Room> Get()
    {
        return _user.GetAvailabelRooms();
    }

    [HttpPost("{roomNumber}/{guestName}")]
    public string PostBookARoom(int roomNumber, string guestName)
    {
        return _user.BookARoom(roomNumber, guestName);
    }

    [HttpPut("{roomNumber}/{guestName}")]
    public string Put(int roomNumber, string guestName)
    {
        return _user.MoveOut(roomNumber, guestName);
    }
}
