#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WaClient.Worker/WaClient.Worker.csproj", "WaClient.Worker/"]
COPY ["Hotsapp.Data/Hotsapp.Data.csproj", "Hotsapp.Data/"]
COPY ["WaClient.Connector/WaClient.Connector.csproj", "WaClient.Connector/"]
RUN dotnet restore "WaClient.Worker/WaClient.Worker.csproj"
COPY . .
WORKDIR "/src/WaClient.Worker"
RUN dotnet build "WaClient.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WaClient.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WaClient.Worker.dll"]