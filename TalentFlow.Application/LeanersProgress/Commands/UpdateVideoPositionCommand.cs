using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TalentFlow.Application.LeanersProgress.Commands
{
    public record UpdateVideoPositionCommand(Guid LessonId, Guid UserId, int VideoPositionSeconds)
        : IRequest<bool>;
}
