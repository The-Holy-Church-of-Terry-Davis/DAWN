#Config file taken from ahendrix (https://github.com/athendrix)

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["Backend.csproj", "Dawn/"]
RUN dotnet restore "Dawn/Backend.csproj"
COPY . .
WORKDIR /src/Dawn
RUN dotnet build "Dawn/Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dawn/Backend.csproj" -c Release --runtime alpine-x64 --self-contained -o /app/publish

# Publish
FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]
