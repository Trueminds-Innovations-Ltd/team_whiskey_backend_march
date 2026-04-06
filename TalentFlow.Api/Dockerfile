# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only solution + project files first (better caching)
COPY TalentFlow.sln .
COPY TalentFlow.Api/*.csproj TalentFlow.Api/
COPY TalentFlow.Application/*.csproj TalentFlow.Application/
COPY TalentFlow.Domain/*.csproj TalentFlow.Domain/
COPY TalentFlow.Infrastructure/*.csproj TalentFlow.Infrastructure/
COPY TalentFlow.Persistence/*.csproj TalentFlow.Persistence/

# Restore
RUN dotnet restore TalentFlow.sln

# Copy everything else
COPY . .

# Publish
RUN dotnet publish TalentFlow.Api/TalentFlow.Api.csproj -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TalentFlow.Api.dll"]