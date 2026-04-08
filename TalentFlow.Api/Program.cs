using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Users.Commands;
using TalentFlow.Infrastructure.Auth;
using TalentFlow.Infrastructure.Events;
using TalentFlow.Infrastructure.Security;
using TalentFlow.Infrastructure.Services;
using TalentFlow.Persistence;
using TalentFlow.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ✅ Controllers
builder.Services.AddControllers();

// ✅ Swagger (always enabled, including production)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ DbContext (Render/Postgres)
builder.Services.AddDbContext<TalentFlowDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Hosted service for DB migration/seed
//builder.Services.AddHostedService<DatabaseInitializerHostedService>();

Console.WriteLine("Connection string: " + builder.Configuration.GetConnectionString("DefaultConnection"));
Console.WriteLine("JWT Secret: " + builder.Configuration["Jwt:Secret"]);

// ✅ Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddScoped<IEventStreamPublisher, EventStreamPublisher>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();

// ✅ Services
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<JwtTokenService>();

// ✅ MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); // API layer
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly); // Application layer
});

// ✅ Authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        RoleClaimType = System.Security.Claims.ClaimTypes.Role
    };
});

// ✅ Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireInstructor", policy => policy.RequireRole("Instructor"));
    options.AddPolicy("RequireLearner", policy => policy.RequireRole("Learner"));
});

var app = builder.Build();

// ✅ Swagger (always enabled, including production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TalentFlow API v1");
    c.RoutePrefix = string.Empty; // Swagger UI at root "/"
});

// ✅ Middleware order
app.UseAuthentication();
app.UseAuthorization();

// ✅ Map controllers
app.MapControllers();

app.Run();
