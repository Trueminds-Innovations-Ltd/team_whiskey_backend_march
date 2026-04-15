using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TalentFlow.Application.LeanersProgress.DTOs;

namespace TalentFlow.Application.LeanersProgress.Commands
{
    public record MarkLessonCompleteCommand(Guid LessonId, Guid UserId) : IRequest<LeanerCompletionDto>;
}
