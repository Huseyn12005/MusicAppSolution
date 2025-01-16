FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MusicService/MusicService.csproj", "MusicService/"]
RUN dotnet restore "MusicService/MusicService.csproj"
COPY . .
WORKDIR "/src/MusicService"
RUN dotnet build "MusicService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicService.dll"]
