# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["HotelApi.csproj", "./"]
RUN dotnet restore "./HotelApi.csproj"

COPY . .
RUN dotnet build "HotelApi.csproj" -c Release -o /app/build

# Этап публикации
FROM build as publish
RUN dotnet publish "HotelApi.csproj" -c Release -o /app/publish

# Этап выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "HotelApi.dll"]