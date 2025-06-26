using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers;

/// <summary>
/// Контроллер для работы с Пользователями (вывод свободных номеров, бронирование, выселение)
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
    /// Вывод списка не забронированных номеров
    /// </summary>
    /// <returns>Список номеров</returns>
    [HttpGet]
    public IEnumerable<Room> Get()
    {
        return _user.GetAvailabelRooms();
    }

    /// <summary>
    /// Бронирование номера
    /// </summary>
    /// <param name="roomNumber">Номер апартаментов</param>
    /// <param name="guestName">Имя гостя</param>
    /// <returns></returns>
    [HttpPost("{roomNumber}/{guestName}")]
    public string PostBookARoom(int roomNumber, string guestName)
    {
        return _user.BookARoom(roomNumber, guestName);
    }

    /// <summary>
    /// Выселение из номера
    /// </summary>
    /// <param name="roomNumber">Номер апартаментов</param>
    /// <param name="guestName">Имя гостя</param>
    /// <returns></returns>
    [HttpPut("{roomNumber}/{guestName}")]
    public string Put(int roomNumber, string guestName)
    {
        return _user.MoveOut(roomNumber, guestName);
    }
}
