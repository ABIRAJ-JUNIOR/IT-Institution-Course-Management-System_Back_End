﻿using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface INotificationRepository
    {
        ICollection<NotificationResponseDTO> GetAllNotifications();
        void AddNotification(NotificationRequestDTO notification);
        void DeleteNotification(int id);
    }
}

