FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Tüm proje dosyalarını kopyala
COPY ["APIs/ApiGateway/ApiGateway.csproj", "APIs/ApiGateway/"]
COPY ["APIs/EmployerService/JobPortal.EmployerService.API/JobPortal.EmployerService.API.csproj", "APIs/EmployerService/JobPortal.EmployerService.API/"]
COPY ["APIs/JobPostingService/JobPortal.JobPostingService.API/JobPortal.JobPostingService.API.csproj", "APIs/JobPostingService/JobPortal.JobPostingService.API/"]

# Tüm projeleri restore et
#RUN dotnet restore "APIs/ApiGateway/ApiGateway.csproj"
#RUN dotnet restore "APIs/EmployerService/JobPortal.EmployerService.API/JobPortal.EmployerService.API.csproj"
#RUN dotnet restore "APIs/JobPostingService/JobPortal.JobPostingService.API/JobPortal.JobPostingService.API.csproj"

# Tüm kaynak kodları kopyala
COPY . .
# Employer Service'i derle ve yayınla
WORKDIR "/src/APIs/EmployerService/JobPortal.EmployerService.API"
RUN dotnet build "JobPortal.EmployerService.API.csproj" -c Release -o /app/build/employer
RUN dotnet publish "JobPortal.EmployerService.API.csproj" -c Release -o /app/publish/employer

# Job Posting Service'i derle ve yayınla
WORKDIR "/src/APIs/JobPostingService/JobPortal.JobPostingService.API"
RUN dotnet build "JobPortal.JobPostingService.API.csproj" -c Release -o /app/build/jobposting
RUN dotnet publish "JobPortal.JobPostingService.API.csproj" -c Release -o /app/publish/jobposting

# API Gateway'i derle ve yayınla
WORKDIR "/src/APIs/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build/gateway
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish/gateway

FROM base AS employer
WORKDIR /app
COPY --from=build /app/publish/employer .
ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet JobPortal.EmployerService.Persistence.dll"]
ENTRYPOINT ["dotnet", "JobPortal.EmployerService.API.dll"]

FROM base AS jobposting
WORKDIR /app
COPY --from=build /app/publish/jobposting .
ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet JobPortal.JobPostingService.Persistence.dll"]
ENTRYPOINT ["dotnet", "JobPortal.JobPostingService.API.dll"] 

FROM base AS gateway
WORKDIR /app
COPY --from=build /app/publish/gateway .
ENV EMPLOYER_SERVICE_PORT=5010
ENV JOB_POSTING_SERVICE_PORT=5020
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
