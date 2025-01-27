FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["APIs/EmployerService/JobPortal.EmployerService.API/JobPortal.EmployerService.API.csproj", "APIs/EmployerService/JobPortal.EmployerService.API/"]
COPY . .
WORKDIR "/src/APIs/EmployerService/JobPortal.EmployerService.API"
RUN dotnet build "JobPortal.EmployerService.API.csproj" -c Release -o /app/build
RUN dotnet publish "JobPortal.EmployerService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Health check
RUN apt-get update && apt-get install -y curl

ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet JobPortal.EmployerService.Persistence.dll"]
ENTRYPOINT ["dotnet", "JobPortal.EmployerService.API.dll"] 