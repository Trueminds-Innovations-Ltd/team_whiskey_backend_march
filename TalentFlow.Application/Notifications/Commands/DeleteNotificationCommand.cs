using System;
using MediatR;

namespace TalentFlow.Application.Notifications.Commands
{
    public record DeleteNotificationCommand(Guid Id, string DeletedBy) : IRequest<bool>;
}
