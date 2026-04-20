# TalentFlow – Backend README

## 📚 Overview
TalentFlow is a recruitment and learning management platform built with **ASP.NET Core**, designed around **Domain‑Driven Design (DDD)** and **Event‑Driven Architecture (EDA)**. It streamlines hiring and course management with:

- Secure authentication & RBAC (JWT + Identity)  
- Course creation & learner enrollment workflows  
- Job posting & candidate tracking  
- Real‑time notifications (SignalR + Email)  
- Resilient event‑driven messaging with retries  
- **Cloud deployment on Render** for scalability and simplicity  

---

## 🏗️ Architecture
```
┌───────────────────────────────┐
│   FRONTEND (Next.js / React)  │
└───────────────┬───────────────┘
                │ REST API
┌───────────────▼───────────────┐
│   Backend API (ASP.NET Core)  │
│ - JWT Authentication + RBAC   │
│ - Courses/Jobs CRUD           │
│ - EF Core ORM + Persistence   │
│ - Domain Events               │
└───────────────┬───────────────┘
                │
        ┌───────▼───────────────┐
        │ Infrastructure Layer   │
        │ - RabbitMQ/Kafka       │
        │ - Hangfire Jobs        │
        │ - SignalR Notifications│
        │ - SMTP/SendGrid Emails │
        │ - Cloud Storage (S3/Blob) │
        │ - Deployment: Render   │
        └────────────────────────┘
```

---

## 🔧 Engines & Frameworks
- **Core**: ASP.NET Core, EF Core, Npgsql, MediatR (CQRS)  
- **Security**: JWT Bearer, Identity Core, BCrypt  
- **Messaging**: RabbitMQ, Kafka, Hangfire  
- **Communication**: SignalR, SendGrid, SMTP  
- **Storage**: Amazon S3, Azure Blob  
- **Resilience**: Polly (retry, circuit breaker)  
- **Validation**: FluentValidation  
- **Logging**: Serilog  
- **Deployment**: Render (containerized ASP.NET Core service)  

---

## 🏛️ Principles
- **DDD**: Clear separation of Domain, Application, Persistence, Infrastructure.  
- **EDA**: Events published to RabbitMQ/Kafka, consumed asynchronously.  
- **Resilience**: Polly + Hangfire ensure retries and fault tolerance.  
- **Observability**: Serilog structured logging across all layers.  
- **Cloud Deployment**: Render handles container orchestration, networking, and scaling.  

---

## 📁 Project Structure
```
talentflow/
├── TalentFlow.Api/              # Controllers, DTOs, Startup
├── TalentFlow.Application/      # Services, UseCases, Interfaces
├── TalentFlow.Domain/           # Entities, ValueObjects, Events
├── TalentFlow.Persistence/      # DbContext, Configurations, Migrations, Repositories
├── TalentFlow.Infrastructure/   # Email, Notifications, Queue, Storage
├── docs/                        # Documentation (API, DB schema, Security)
└── docker-compose.yml           # Local dev infra
```

---

## 🚀 Quick Start
1. Clone repo:
   ```bash
   git clone https://github.com/your-org/talentflow.git
   cd talentflow
   ```
2. Configure `.env`:
   ```
   DATABASE_URL="Host=localhost;Port=5432;Database=talentflow_dev;Username=postgres;Password=yourpassword"
   JWT_SECRET="your-secret-key"
   ```
3. Run migrations:
   ```bash
   dotnet ef database update -p TalentFlow.Persistence -s TalentFlow.Api
   ```
4. Start app locally:
   ```bash
   dotnet run --project TalentFlow.Api
   ```

---

## 🌐 Deployment Guide (Render)
1. **Push code to GitHub** (or GitLab/Bitbucket).  
2. **Create a new Render Web Service**:  
   - Select your repo.  
   - Choose **Dockerfile** or **.NET environment**.  
3. **Configure Environment Variables** in Render dashboard:  
   - `DATABASE_URL`  
   - `JWT_SECRET`  
   - `RABBITMQ_URL` (if using queues)  
   - `SENDGRID_API_KEY` (if using SendGrid)  
4. **Build & Deploy**: Render automatically builds and runs the container.  
5. **Access your app**:  
   ```
   https://talentflow-<id>.onrender.com
   ```
6. **Logs & Monitoring**:  
   - View logs in Render dashboard.  
   - Configure alerts for failed builds or crashes.  

---

## 📚 Workflows

### Course Creation
- Instructor calls `POST /api/Course`.  
- Controller → Application (MediatR Command).  
- Domain creates `Course` entity, raises `CourseCreated`.  
- Persistence saves via EF Core.  
- Event bus publishes `CourseCreated`.  
- Notification service sends SignalR + email.  
- Polly/Hangfire retry if external calls fail.  

### Learner Enrollment
- Learner calls `POST /api/enroll`.  
- Controller validates JWT, forwards command.  
- Domain creates `Enrollment` aggregate, raises `LearnerEnrolled`.  
- Persistence saves enrollment.  
- Event bus publishes event.  
- Consumers update analytics, grant access, send notifications.  
- Resilience via Polly + Hangfire ensures reliability.  

---

## 🧪 Testing
- Unit tests: `dotnet test`  
- Integration tests: `dotnet test --filter Category=Integration`  
- Coverage goal: 80%+ overall, 90%+ on critical paths.  

---

## 📈 Observability
- **Serilog** structured logs.  
- Metrics for event throughput, retries, and failures.  
- Dead‑letter queues for failed messages.  

---

## 📄 License
Private – All rights reserved © 2026 TalentFlow

Would you like me to also add a **CI/CD section** (GitHub Actions → Render auto‑deploy pipeline) so the README covers continuous deployment too?
