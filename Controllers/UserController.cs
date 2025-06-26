using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers;

/// <summary>
/// ���������� ��� ������ � �������������� (����� ��������� �������, ������������, ���������)
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _user;

    public UserController(IUserService user)
    {
        _user = user;
    }

    /// <summary>
    /// ����� ������ �� ��������������� �������
    /// </summary>
    /// <returns>������ �������</returns>
    [HttpGet]
    public IEnumerable<Room> Get()
    {
        return _user.GetAvailabelRooms();
    }

    /// <summary>
    /// ������������ ������
    /// </summary>
    /// <param name="roomNumber">����� ������������</param>
    /// <param name="guestName">��� �����</param>
    /// <returns></returns>
    [HttpPost("{roomNumber}/{guestName}")]
    public string PostBookARoom(int roomNumber, string guestName)
    {
        return _user.BookARoom(roomNumber, guestName);
    }

    /// <summary>
    /// ��������� �� ������
    /// </summary>
    /// <param name="roomNumber">����� ������������</param>
    /// <param name="guestName">��� �����</param>
    /// <returns></returns>
    [HttpPut("{roomNumber}/{guestName}")]
    public string Put(int roomNumber, string guestName)
    {
        return _user.MoveOut(roomNumber, guestName);
    }
}
