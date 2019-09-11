FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hotsapp.ServiceManager/Hotsapp.ServiceManager.csproj", "Hotsapp.ServiceManager/"]
RUN dotnet restore "Hotsapp.ServiceManager/Hotsapp.ServiceManager.csproj"
COPY . .
WORKDIR "/src/Hotsapp.ServiceManager"
RUN dotnet build "Hotsapp.ServiceManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotsapp.ServiceManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hotsapp.ServiceManager.dll"]