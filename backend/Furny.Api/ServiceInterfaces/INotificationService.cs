﻿using Furny.Data;
using Furny.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(string userId, Notification notification);

        Task DoneNotificationAsync(string userId, string notificationId);

        Task<IList<NotificationCommand>> GetNotificationsAsync(string userId);
    }
}