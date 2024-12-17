# Unter https://aka.ms/customizecontainer erfahren Sie, wie Sie Ihren Debugcontainer anpassen und wie Visual Studio dieses Dockerfile verwendet, um Ihre Images für ein schnelleres Debuggen zu erstellen.

# Diese Stufe wird verwendet, wenn sie von VS im Schnellmodus ausgeführt wird (Standardeinstellung für Debugkonfiguration).
FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble-chiseled-extra AS base
USER $APP_UID
WORKDIR /app
EXPOSE 7232

# Diese Stufe wird zum Erstellen des Dienstprojekts verwendet.
FROM mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/StarWarsService/StarWarsService.csproj", "src/StarWarsService/"]
COPY ["src/Shared/Shared.csproj", "src/Shared/"]
COPY ["src/SqliteDb/SqliteDb.csproj", "src/SqliteDb/"]
RUN dotnet restore "./src/StarWarsService/StarWarsService.csproj"
COPY . .
WORKDIR "/src/src/StarWarsService"
RUN dotnet build "./StarWarsService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Diese Stufe wird verwendet, um das Dienstprojekt zu veröffentlichen, das in die letzte Phase kopiert werden soll.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StarWarsService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Diese Stufe wird in der Produktion oder bei Ausführung von VS im regulären Modus verwendet (Standard, wenn die Debugkonfiguration nicht verwendet wird).
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StarWarsService.dll"]