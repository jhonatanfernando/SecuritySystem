#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SecuritySystem.Web.Host/SecuritySystem.Web.Host.csproj", "src/SecuritySystem.Web.Host"]
RUN dotnet restore "src/SecuritySystem.Web.Host"

COPY ["SecuritySystem.Core/SecuritySystem.Core.csproj", "src/SecuritySystem.Core"]
RUN dotnet restore "src/SecuritySystem.Core"

COPY ["SecuritySystem.Application/SecuritySystem.Application.csproj", "src/SecuritySystem.Application"]
RUN dotnet restore "src/SecuritySystem.Application"

COPY ["SecuritySystem.EntityFrameworkCore/SecuritySystem.EntityFrameworkCore.csproj", "src/SecuritySystem.EntityFrameworkCore"]
RUN dotnet restore "src/SecuritySystem.EntityFrameworkCore"


WORKDIR "/src/src"
COPY /SecuritySystem.Web.Host/. /SecuritySystem.Web.Host
COPY /SecuritySystem.Core/. /SecuritySystem.Core
COPY /SecuritySystem.Application/. /SecuritySystem.Application
COPY /SecuritySystem.EntityFrameworkCore/. /SecuritySystem.EntityFrameworkCore
RUN dotnet build "/SecuritySystem.Web.Host/SecuritySystem.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/SecuritySystem.Web.Host/SecuritySystem.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecuritySystem.Web.Host.dll"]