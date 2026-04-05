namespace TalentFlow.Application.Courses.DTOs
{
    public class CourseDto
    {
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<EnrollmentDto> Enrollments { get; set; } = new();
    }

    public class EnrollmentDto
    {
        public Guid UserId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
