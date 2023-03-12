#Config file taken from ahendrix (https://github.com/athendrix)

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["Backend.csproj", "Dawn/"]
RUN dotnet restore "Dawn/Backend.csproj"
COPY . ./Dawn
WORKDIR /src/Dawn
RUN dotnet build "Backend.csproj" -c Release -o /app/build
ENTRYPOINT [ "dotnet", "run" ]
