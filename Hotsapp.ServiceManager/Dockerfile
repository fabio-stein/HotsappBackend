FROM fabiolux/yowsup AS dev

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
COPY --from=dev / /
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hotsapp.ServiceManager/Hotsapp.ServiceManager.csproj", "Hotsapp.ServiceManager/"]
COPY ["Hotsapp.Data/Hotsapp.Data.csproj", "Hotsapp.Data/"]
COPY ["Hotsapp.ServiceManager/Assets", "Assets"]
RUN dotnet restore "Hotsapp.ServiceManager/Hotsapp.ServiceManager.csproj"
COPY . .
WORKDIR "/src/Hotsapp.ServiceManager"
RUN dotnet build "Hotsapp.ServiceManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotsapp.ServiceManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=build /src/Assets /app/Assets

ENV LANG C.UTF-8
ENV LC_ALL C.UTF-8

ENTRYPOINT ["dotnet", "Hotsapp.ServiceManager.dll"]