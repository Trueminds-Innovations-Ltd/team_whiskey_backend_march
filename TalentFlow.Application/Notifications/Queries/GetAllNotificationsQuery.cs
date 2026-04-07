using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Notifications.DTOs;

namespace TalentFlow.Application.Notifications.Queries
{
    public record GetAllNotificationsQuery() : IRequest<List<NotificationDto>>;
}
