using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationsRepository;

        public NotificationController(INotificationRepository notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }
        [HttpGet("Get-All-Notifications")]

        public IActionResult GetAllCourseNotifications()
        {
            var notificationList = _notificationsRepository.GetAllNotifications();
            return Ok(notificationList);
        }

        [HttpPost("Add-Notification")]

        public IActionResult AddCourseNotification(NotificationRequestDTO notification)
        {
            _notificationsRepository.AddNotification(notification);
            return Ok("Notification Added Successfully..");
        }
    }
}
