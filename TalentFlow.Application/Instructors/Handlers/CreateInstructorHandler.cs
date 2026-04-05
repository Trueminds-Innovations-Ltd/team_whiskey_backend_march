using MediatR;
using TalentFlow.Application.Instructors.Commands;
using TalentFlow.Application.Instructors.DTOs;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Instructors.Handlers
{
    public class CreateInstructorHandler : IRequestHandler<CreateInstructorCommand, InstructorDto>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInstructorHandler(IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InstructorDto> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = new Instructor(request.FullName, request.Email, request.Bio);

            await _instructorRepository.AddAsync(instructor, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new InstructorDto
            {
                Id = instructor.Id,
                FullName = instructor.FullName,
                Email = instructor.Email,
                Bio = instructor.Bio
            };
        }
    }
}
