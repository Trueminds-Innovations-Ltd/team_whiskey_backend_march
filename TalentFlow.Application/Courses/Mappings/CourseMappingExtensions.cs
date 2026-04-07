using TalentFlow.Domain.Entities;
using TalentFlow.Application.Courses.DTOs;

namespace TalentFlow.Application.Courses.Mappings
{
    public static class CourseMappingExtensions
    {
        public static CourseDto ToDto(this Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Slug = course.Slug
            };
        }
    }
}
