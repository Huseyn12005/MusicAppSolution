# Use the base ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["IdentityService/IdentityService.csproj", "IdentityService/"]
RUN dotnet restore "IdentityService/IdentityService.csproj"

# Copy the entire project and build the application
COPY . .
WORKDIR "/src/IdentityService"
RUN dotnet build "IdentityService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IdentityService.csproj" -c $BUILD_CONFIGURATION -o /app/publish --no-restore /p:UseAppHost=false

# Use the base runtime image for the final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.dll"]
