FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["notification-channel-parser/notification-channel-parser.csproj", "notification-channel-parser/"]
RUN dotnet restore "notification-channel-parser/notification-channel-parser.csproj"
COPY . .
WORKDIR "/src/notification-channel-parser"
RUN dotnet build "notification-channel-parser.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "notification-channel-parser.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "notification-channel-parser.dll"]
