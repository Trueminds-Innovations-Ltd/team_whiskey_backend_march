using System;
using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Certificates.DTOs;

namespace TalentFlow.Application.Certificates.Queries
{
    public record GetCertificatesByUserIdQuery(Guid UserId)
        : IRequest<List<CertificateDto>>;
}
