using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Certificates.Commands;
using TalentFlow.Application.Certificates.DTOs;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Common.Mappings; // ✅ FIX
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Certificates.Handlers
{
    public class CreateCertificateHandler
        : IRequestHandler<CreateCertificateCommand, CertificateDto>
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCertificateHandler(
            ICertificateRepository certificateRepository,
            IUnitOfWork unitOfWork)
        {
            _certificateRepository = certificateRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CertificateDto> Handle(
            CreateCertificateCommand request,
            CancellationToken cancellationToken)
        {
            var certificate = new Certificate(
                request.LearnerId,
                request.CourseId,
                request.IssuedBy,
                request.ExpiresAt
            );

            await _certificateRepository.AddAsync(certificate, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return certificate.ToDto(); // ✅ now works
        }
    }
}