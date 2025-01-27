FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["APIs/JobPostingService/JobPortal.JobPostingService.API/JobPortal.JobPostingService.API.csproj", "APIs/JobPostingService/JobPortal.JobPostingService.API/"]
COPY . .
WORKDIR "/src/APIs/JobPostingService/JobPortal.JobPostingService.API"
RUN dotnet build "JobPortal.JobPostingService.API.csproj" -c Release -o /app/build
RUN dotnet publish "JobPortal.JobPostingService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Health check
RUN apt-get update && apt-get install -y curl

ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet JobPortal.JobPostingService.Persistence.dll"]
ENTRYPOINT ["dotnet", "JobPortal.JobPostingService.API.dll"] 