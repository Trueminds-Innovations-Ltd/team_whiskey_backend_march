using MediatR;
using TalentFlow.Application.Instructors.Queries;
using TalentFlow.Application.Instructors.DTOs;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Instructors.Handlers
{
    public class GetInstructorByIdHandler : IRequestHandler<GetInstructorByIdQuery, InstructorDto?>
    {
        private readonly IInstructorRepository _instructorRepository;

        public GetInstructorByIdHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<InstructorDto?> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetByIdAsync(request.Id, cancellationToken);
            if (instructor == null) return null;

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
