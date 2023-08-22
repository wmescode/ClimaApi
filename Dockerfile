#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Clima.Api/Clima.Api.csproj", "Clima.Api/"]
COPY ["Clima.Application/Clima.Application.csproj", "Clima.Application/"]
COPY ["Clima.Domain/Clima.Domain.csproj", "Clima.Domain/"]
COPY ["Clima.IoC/Clima.IoC.csproj", "Clima.IoC/"]
COPY ["Clima.Infra.Data/Clima.Infra.Data.csproj", "Clima.Infra.Data/"]
RUN dotnet restore "Clima.Api/Clima.Api.csproj"
COPY . .
WORKDIR "/src/Clima.Api"
RUN dotnet build "Clima.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clima.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clima.Api.dll"]