FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["APIs/ApiGateway/ApiGateway.csproj", "APIs/ApiGateway/"]
COPY . .
WORKDIR "/src/APIs/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.dll"] 