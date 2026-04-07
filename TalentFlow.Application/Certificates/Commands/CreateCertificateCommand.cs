using System;
using MediatR;
using TalentFlow.Application.Certificates.DTOs;

namespace TalentFlow.Application.Certificates.Commands
{
    public record CreateCertificateCommand(
        Guid LearnerId,
        Guid CourseId,
        string IssuedBy,
        DateTime? ExpiresAt
    ) : IRequest<CertificateDto>;
}
