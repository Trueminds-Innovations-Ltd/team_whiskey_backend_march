using Microsoft.Extensions.DependencyInjection;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Persistence;
using TalentFlow.Persistence.Repositories;

namespace TalentFlow.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<TalentFlowDbContext>();

            // Register repositories
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IProgressRepository, ProgressRepository>();

            // Add others as needed (Course, User, Enrollment, etc.)
            return services;
        }
    }
}
